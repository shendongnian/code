    public static string Remove(this string source, string remove,  int firstN)
        {
            if(firstN <= 0 || string.IsNullOrEmpty(source) || string.IsNullOrEmpty(remove))
            {
                return source;
            }
            int index = source.IndexOf(remove);
            return index < 0 ? source : source.Remove(index, remove.Length).Remove(remove, --firstN);
        }
