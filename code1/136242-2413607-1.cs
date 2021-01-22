    public class StringTemplate
    {
        private string _template;
        private static Regex _regex = new Regex(@"(?<open>{+)(?<key>\w+)(?<format>:[^}]+)?(?<close>}+)", RegexOptions.Compiled);
        public StringTemplate(string template)
        {
            template.CheckArgumentNull("template");
            this._template = template;
            ParseTemplate();
        }
        private string _templateWithIndexes;
        private List<string> _placeholders;
        private void ParseTemplate()
        {
            _placeholders = new List<string>();
            MatchEvaluator evaluator = (m) =>
            {
                if (m.Success)
                {
                    string open = m.Groups["open"].Value;
                    string close = m.Groups["close"].Value;
                    string key = m.Groups["key"].Value;
                    string format = m.Groups["format"].Value;
                    if (open.Length % 2 == 0)
                        return m.Value;
                    open = RemoveLastChar(open);
                    close = RemoveLastChar(close);
                    if (!_placeholders.Contains(key))
                    {
                        _placeholders.Add(key);
                    }
                    int index = _placeholders.IndexOf(key);
                    return string.Format("{0}{{{1}{2}}}{3}", open, index, format, close);
                }
                return m.Value;
            };
            _templateWithIndexes = _regex.Replace(_template, evaluator);
        }
        private string RemoveLastChar(string str)
        {
            if (str.Length > 1)
                return str.Substring(0, str.Length - 1);
            else
                return string.Empty;
        }
        public static implicit operator StringTemplate(string s)
        {
            return new StringTemplate(s);
        }
        public override string ToString()
        {
            return _template;
        }
        public string Format(IDictionary<string, object> values)
        {
            values.CheckArgumentNull("values");
            object[] array = new object[_placeholders.Count];
            for(int i = 0; i < _placeholders.Count; i++)
            {
                string key = _placeholders[i];
                object value;
                if (!values.TryGetValue(key, out value))
                {
                    value = string.Format("{{{0}}}", key);
                }
                array[i] = value;
            }
            return string.Format(_templateWithIndexes, array);
        }
        private IDictionary<string, object> MakeDictionary(object obj)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            Type type = obj.GetType();
            foreach (string propName in _placeholders)
            {
                var prop = type.GetProperty(propName);
                if (prop != null)
                    dict.Add(propName, prop.GetValue(obj, null));
            }
            return dict;
        }
        public string Format(object values)
        {
            return Format(MakeDictionary(values));
        }
        public static string Format(string template, IDictionary<string, object> values)
        {
            return new StringTemplate(template).Format(values);
        }
        public static string Format(string template, object values)
        {
            return new StringTemplate(template).Format(values);
        }
    }
