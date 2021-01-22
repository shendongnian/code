        private Dictionary<string, string> getParameters(string[] lines)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                string pName = line.Substring(0, line.IndexOf(' '));
                string pVal = line.Substring(line.IndexOf(' ') + 1);
                results.Add(pName, pVal);
            }
            return results;
        }
