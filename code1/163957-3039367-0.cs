        String UrlEncode(String value)
        {
            StringBuilder result = new StringBuilder();
            foreach (char symbol in value)
            {
                if ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~".IndexOf(symbol) != -1) result.Append(symbol);
                else result.Append("%u" + String.Format("{0:X4}", (int)symbol));
            }
            return result.ToString();
        }
