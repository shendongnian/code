    public static int Test(int num)
    {
       return num  ;
    }
    public static void Function(Func<int,int> predicate, int param)
    {
        predicate(param);
    }
    Function(Test, 5);
