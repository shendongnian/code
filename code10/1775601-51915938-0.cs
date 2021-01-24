    /// <param name="source"> equivalent to TextBox1.Text in original post</param>
    public static int[] ConvertToUtf32(string source)
    {
        int[] result = new int[source.Length]; //equivalent to all the chars displayed in TextBox2.Text in original post
        if (source.Equals(" "))
        {
            result[0] = ' ';
        }
        else
        {
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = Char.ConvertToUtf32(source.Substring(i, 1), 0);
            }
        }
        return result;
    }
