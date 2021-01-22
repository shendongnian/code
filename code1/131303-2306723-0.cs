    String Escape(String s)
    {
        StringBuilder sb = new StringBuilder();
        bool needQuotes = false;
        foreach (char c in s.ToArray())
        {
            switch (c)
            {
                case '"': sb.Append("\\\""); needQuotes = true; break;
                case ' ': sb.Append(" "); needQuotes = true; break;
                case ',': sb.Append(","); needQuotes = true; break;
                case '\t': sb.Append("\\t"); needQuotes = true; break;
                case '\n': sb.Append("\\n"); needQuotes = true; break;
                default: sb.Append(c); break;
            }
        }
        if (needQuotes)
            return "\"" + sb.ToString() + "\"";
        else
            return sb.ToString();
    }
    public void SerializeAsCsv(Stream stream)
    {
        stream.Write(Escape(Name));
        stream.Write(",");
        stream.Write(Year.ToString());
        stream.Write(",");
        stream.Write(Escape(Model));
        stream.Write("\n");
    }
