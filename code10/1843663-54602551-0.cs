    public class Matrix
    {
        dynamic matrix;
     
        Matrix(int x,int y,string type)
        {
            switch (type)
            {
                case "int":
                    matrix = 
                       Enumerable.Repeat(0, x).Select(_ => new int[y]).ToArray();
                    break;
                case "double":
                    //initialize a double 2d array
                    matrix = 
                       Enumerable.Repeat(0, x).Select(_ => new double[y]).ToArray();
                    break;
                case "float":
                default:
                    //initialize a float 2d array
                    matrix = 
                       Enumerable.Repeat(0, x).Select(_ => new float[y]).ToArray();
                    break;
             }
         }
     }
