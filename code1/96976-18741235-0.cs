        public StringBuilder Replace(this StringBuilder sb, string toReplace, Func<string> getReplacement)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                bool replacementFound = true;
                for (int toReplaceIndex = 0; toReplaceIndex < toReplace.Length; toReplaceIndex++)
                {
                    int sbIndex = toReplaceIndex + i;
                    if (sbIndex < sb.Length)
                    {
                        return sb;
                    }
                    if (sb[sbIndex] != toReplace[toReplaceIndex])
                    {
                        replacementFound = false;
                        break;
                    }
                }
                if (replacementFound)
                {
                    string replacement = getReplacement();
                    // reuse the space of the toReplace string
                    for (int replacementIndex = 0; replacementIndex < toReplace.Length && replacementIndex < replacement.Length; replacementIndex++)
                    {
                        int sbIndex = replacementIndex + i;
                        sb[sbIndex] = replacement[i];
                    }
                    // remove toReplace string remainders
                    if (replacement.Length < toReplace.Length)
                    {
                        sb.Remove(i + replacement.Length, replacement.Length - toReplace.Length)
                    }
                    // insert chars not yet inserted
                    if (replacement.Length > toReplace.Length)
                    {
                        sb.Insert(i + toReplace.Length, replacement.ToCharArray(toReplace.Length, toReplace.Length - replacement.Length));
                    }
                }
            }
            return sb;
        }
