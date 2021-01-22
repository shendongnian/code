        public static bool In<T>(this T X, params T[] list)
        {
            foreach (var item in list)
            {
                if (X.Equals(item))
                    return true;
            }
            return false;
        }
