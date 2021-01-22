        protected class Columns
        {
            public static int MaxFactCell = 7;
        };
        protected class Columns2 : Columns
        {
            static Columns2()
            {
                MaxFactCell = 13;
            }
        };
