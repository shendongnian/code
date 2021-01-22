    public static IEnumerable<string> WordList(this string Text,string Word)
            {
                int cIndex = 0;
                int nIndex;
                while ((nIndex = Text.IndexOf(Word, cIndex + 1)) != -1)
                {
                    int sIndex = (cIndex == 0 ? 0 : cIndex + 1);
                    yield return Text.Substring(sIndex, nIndex - sIndex);
                    cIndex = nIndex;
                }
                yield return Text.Substring(cIndex + 1);
            }
    public static IEnumerable<string> WordList(this string Text, char c)
            {
                int cIndex = 0;
                int nIndex;
                while ((nIndex = Text.IndexOf(c, cIndex + 1)) != -1)
                {
                    int sIndex = (cIndex == 0 ? 0 : cIndex + 1);
                    yield return Text.Substring(sIndex, nIndex - sIndex);
                    cIndex = nIndex;
                }
                yield return Text.Substring(cIndex + 1);
            }
