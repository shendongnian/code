        public static object[] GetRow()
        {
            object[,] test = new object[10,10];
            int a = 0;
            object[] row = new object[10];
            for(a = 0; a <= 10; a++)
            {
                row[a] = test[0, a];
            }
            return row;
        }
