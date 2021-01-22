    public static string AddSpace(this String string, int size)
    {
       String spaceString = new String();
       for(int i = 0; i < size; i++)
       {
          spaceString += " ";
       }
       
       return spaceString;
    }
