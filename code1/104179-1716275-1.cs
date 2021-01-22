    public static string AddSpace(this String string, int size)
    {
       for(int i = 0; i < size; i++)
       {
          string += " ";
       }
       
       return string;
    }
