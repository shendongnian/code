    public string MagicFunction2(string str, string prefix)
    {
        bool first = true;
        using(StringWriter writer = new StringWriter())
        using(StringReader reader = new StringReader(str))
        {
            string line;
            while((line = reader.ReadLine()) != null)
            {
                if (!first)
                    writer.WriteLine();
                writer.Write(prefix + line);
                first = false;
            }
            return writer.ToString();
        }
    }
