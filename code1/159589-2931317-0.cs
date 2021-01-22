        private string Reverse(string text)
        {
            char[] c = text.ToCharArray(0, text.Length);
            Array.Reverse(c);
            return new string(c);
        }
