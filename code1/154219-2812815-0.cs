    static void func1(object parameter)
    {
       // Do stuff here.
    }
    static void Main(string[] args)
    {
      List<string> obj1 = new List<string>();
      Thread t1 = new Thread(func1);
      t1.Start(obj1);
    }
