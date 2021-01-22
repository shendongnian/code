    private static string RemoveBom(string p)
    {
         string BOMMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
         if (p.StartsWith(BOMMarkUtf8))
             p = p.Remove(0, BOMMarkUtf8.Length);
         return p.Replace("\0", "");
    }
