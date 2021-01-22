    public class StringTemplate
    {
      private string _template;
      private string[] _parts;
      private int[] _tokens;
      private string[] _parameters;
      private Dictionary<string, int> _parameterIndices;
      private string[] _replaceGraph;
      private Action<StreamWriter>[] _callbackGraph;
      private bool[] _graphTypeIsReplace;
      public string[] Parameters
      {
        get { return _parameters; }
      }
      public StringTemplate(string template)
      {
        _template = template;
        Prepare();
      }
      public void SetParameter(string name, string replacement)
      {
        int index = _parameterIndices[name] + _parts.Length;
        _replaceGraph[index] = replacement;
        _graphTypeIsReplace[index] = true;
      }
      public void SetParameter(string name, Action<StreamWriter> callback)
      {
        int index = _parameterIndices[name] + _parts.Length;
        _callbackGraph[index] = callback;
        _graphTypeIsReplace[index] = false;
      }
      private static Regex _parser = new Regex(@"\$(\w{1,64})\$", RegexOptions.Compiled);
      private void Prepare()
      {
        _parameterIndices = new Dictionary<string, int>(64);
        List<string> parts = new List<string>(64);
        List<object> tokens = new List<object>(64);
        int param_index = 0;
        int part_start = 0;
        foreach (Match match in _parser.Matches(_template))
        {
          if (match.Index > part_start)
          {
            //Add Part
            tokens.Add(parts.Count);
            parts.Add(_template.Substring(part_start, match.Index - part_start));
          }
          //Add Parameter
          var param = _template.Substring(match.Index + 1, match.Length - 2);
          if (!_parameterIndices.TryGetValue(param, out param_index))
            _parameterIndices[param] = param_index = _parameterIndices.Count;
          tokens.Add(param);
          part_start = match.Index + match.Length;
        }
        //Add last part, if it exists.
        if (part_start < _template.Length)
        {
          tokens.Add(parts.Count);
          parts.Add(_template.Substring(part_start, _template.Length - part_start));
        }
        //Set State
        _parts = parts.ToArray();
        _tokens = new int[tokens.Count];
        int index = 0;
        foreach (var token in tokens)
        {
          var parameter = token as string;
          if (parameter == null)
            _tokens[index++] = (int)token;
          else
            _tokens[index++] = _parameterIndices[parameter] + _parts.Length;
        }
        _parameters = _parameterIndices.Keys.ToArray();
        int graphlen = _parts.Length + _parameters.Length;
        _callbackGraph = new Action<StreamWriter>[graphlen];
        _replaceGraph = new string[graphlen];
        _graphTypeIsReplace = new bool[graphlen];
        for (int i = 0; i < _parts.Length; i++)
        {
          _graphTypeIsReplace[i] = true;
          _replaceGraph[i] = _parts[i];
        }
      }
      public void GenerateString(Stream output)
      {
        var writer = new StreamWriter(output);
        GenerateString(writer);
        writer.Flush();
      }
      public void GenerateString(StreamWriter writer)
      {
        //Resolve graph
        foreach(var token in _tokens)
        {
          if (_graphTypeIsReplace[token])
            writer.Write(_replaceGraph[token]);
          else
            _callbackGraph[token](writer);
        }
      }
      public void SetReplacements(params string[] parameters)
      {
        int index;
        for (int i = 0; i < _parameters.Length; i++)
        {
          if (!Int32.TryParse(_parameters[i], out index))
            continue;
          else
            SetParameter(index.ToString(), parameters[i]);
        }
      }
      public string GenerateString(int bufferSize = 1024)
      {
        using (var ms = new MemoryStream(bufferSize))
        {
          GenerateString(ms);
          ms.Position = 0;
          using (var reader = new StreamReader(ms))
            return reader.ReadToEnd();
        }
      }
      public string GenerateString(params string[] parameters)
      {
        SetReplacements(parameters);
        return GenerateString();
      }
      public void GenerateString(StreamWriter writer, params string[] parameters)
      {
        SetReplacements(parameters);
        GenerateString(writer);
      }
    }
