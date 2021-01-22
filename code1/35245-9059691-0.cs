        static class A : object
        {
            public static new string ToString()
            {
                return "I am object A";
            }
            public static new int GetHashCode()
            {
                return ToString().GetHashCode();
            }
        }
