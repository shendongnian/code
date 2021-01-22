    public static string NaiveConcatenate(IEnumerable<string> sequence)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append('{');
        IEnumerator<string> enumerator = sequence.GetEnumerator();
        if (enumerator.MoveNext())
        {
            string a = enumerator.Current;
            if (!enumerator.MoveNext())
            {
                sb.Append(a);
            }
            else
            {
                string b = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    sb.Append(a);
                    sb.Append(", ");
                    a = b;
                    b = enumerator.Current;
                }
                sb.AppendFormat("{0} and {1}", a, b);
            }
        }
        sb.Append('}');
        return sb.ToString();
    }
