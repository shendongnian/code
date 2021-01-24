    private IEnumerable<string> GetStatement(string sqlFile)
    {
        using (var sr = new StreamReader(sqlFile))
        {
            string s;
            var sb = new StringBuilder();
            while ((s = sr.ReadLine()) != null)
            {
                if (s.Trim().Equals("GO", StringComparison.InvariantCultureIgnoreCase))
                {
                    yield return sb.ToString();
                    sb.Clear();
                    continue;
                }
                sb.AppendLine(s);
            }
            yield return sb.ToString();
        }
    }
