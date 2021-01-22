    public class Class1
        {
            const int CountOfEntries = 17700; //or what ever the count is
            IEnumerable<KeyValuePair<int, string>> load()
            {
                using (var reader = File.OpenText("somefile"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var pair = line.Split(',');
                        yield return new KeyValuePair<int, string>(int.Parse(pair[0]), pair[1]);
                    }
                }
            }
    
            private static Dictionary<int, string> _lookup = new Dictionary<int, string>();
            private static IEnumerator<KeyValuePair<int, string>> _loader = null;
            private string LookUp(int index)
            {
                
                if (_lookup.Count < CountOfEntries && !_lookup.ContainsKey(index))
                {
                    if(_loader == null)
                    {
                        _loader = load().GetEnumerator();
                    }
                    while(_loader.MoveNext())
                    {
                        var pair = _loader.Current;
                        _lookup.Add(pair.Key,pair.Value);
                        if (pair.Key == index)
                        {
                            return index;
                        }
                    }
                }
                if (_lookup.ContainsKey(index))
                {
                    return _lookup[index];
                }
                throw new KeyNotFoundException("The given index was not found");
            }
        }
