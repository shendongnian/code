    System.Reflection.Assembly []ar=AppDomain.CurrentDomain.GetAssemblies();
               
    foreach (System.Reflection.Assembly a in ar)
    {
     Console.WriteLine("{0}", a.FullName);
    }
