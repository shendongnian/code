    List<int> ints = new List<int> { 0, 0, 0, 0 };
    
    System.Diagnostics.Debug.WriteLine("First int - do something special" + ints.FirstOrDefault().ToString());
    foreach (int i in ints.Skip(1))
    {
        {
            System.Diagnostics.Debug.WriteLine("int Do something else");
        }
    }
