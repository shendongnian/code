    public static string CreateSubjectSEO(string str)
        {
            int ci;
            char[] arr = str.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                ci = Convert.ToInt32(arr[i]);
                if (!((ci > 47 && ci < 58) || (ci > 64 && ci < 91) || (ci > 96 && ci < 123)))
                {
                    arr[i] = '-';
                }
            }
            return new string(arr);
        }
