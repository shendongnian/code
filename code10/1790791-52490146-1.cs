    static void Main(string[] args)
    {
        int[] sArray = new int[]{1,2,3};
        SomeMethod(sArray.TryGet(0));
        SomeMethod(sArray.TryGet(1));
        SomeMethod(sArray.TryGet(2));
        SomeMethod(sArray.TryGet(3));
    }
