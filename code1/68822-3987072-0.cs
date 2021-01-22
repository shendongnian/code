        static string Escape(string input)
        {
            StringBuilder builder = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                if (Path.GetInvalidPathChars().Contains(input[i]) || Path.GetInvalidFileNameChars().Contains(input[i]) || input[i] == '%')
                {
                    builder.Append(Uri.HexEscape(input[i]));
                }
                else
                {
                    builder.Append(input[i]);
                }
            }
            return builder.ToString();
        }
        static string Unescape(string input)
        {
            StringBuilder builder = new StringBuilder(input.Length);
            int index = 0;
            while (index < input.Length)
            {
                builder.Append(Uri.HexUnescape(input, ref index));
            }
            return builder.ToString();
        }
