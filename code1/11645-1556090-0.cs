        public static bool NullableValueTryParse(string text, out int? nInt)
        {
            int value;
            if (int.TryParse(text, out value))
            {
                nInt = value;
                return true;
            }
            else
            {
                nInt = null;
                return false;
            }
        }
