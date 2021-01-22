    public static class AppHelp
    {
       private static Form mFrmDummyHost = new Form();
    
       public static void ShowChm()
       {
          Help.ShowHelp(mFrmDummyHost, "my_help.chm");
       }
    }
Of course, all other Help.ShowHelp overloads can be called this way as well.
