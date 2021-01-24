    public class MyArray : int[,]
    {
        string result = "";
        public override string ToString()
        {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 5; j++)
                result += (a1[i,j].ToString() + ",");
        }
        return result;
    }
