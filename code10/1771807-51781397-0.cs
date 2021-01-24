        public static object Concat2(object[,] values)
        {
            string result = "";
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    object value = values[i, j];
                    result += value.ToString();
                }
            }
            return result;
        }
