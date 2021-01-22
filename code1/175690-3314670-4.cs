    public static bool ContainsSequence
        (System.Collections.Generic.IList<object> list, params object[] seq)
    {
        for (int i = 0; i < list.Count() - seq.Count() + 1; i++)
        {
            int j;
            for (j = 0; j < seq.Count(); j++)
            {
                if (list[i + j] != seq[j])
                    break;
            }
            if (j == seq.Count())
                return true;
        }
        return false;
    }
