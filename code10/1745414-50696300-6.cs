    public class MyArray : int[,]
    {
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 5; j++)
                    result += (a1[i,j].ToString() + ",");
            return result;
        }
    }
