    private static string CHAR_REPLACE_SRC = "áàãâÁÀÃÂéèêÉÈEíìîÍÌÎóòõôÓÒÕÔúùûÚÙÛçÇñÑ";
    private static string CHAR_REPLACE_DST = "aaaaAAAAeeeEEEiiiIIIooooOOOOuuuUUUccnN";
    private static string GetCleanString (string src)
    {
        int i = 0;
        while (i < src.Length)
        {
            if (src[i] < 32 || src[i] > 127)
            {
                int pos = CHAR_REPLACE_SRC.IndexOf(src[i]);
                if (pos >= 0)
                    src = src.Replace(CHAR_REPLACE_SRC[pos], CHAR_REPLACE_DST[pos]);
                else
                    src = src.Remove(i, 1);
            }
            else
                i++;
        }
        return src.Replace("\"", "").Replace("?", "").Replace(":", "").Replace("&", "_").Replace("\\", "_").Replace("/", "_");
    }
