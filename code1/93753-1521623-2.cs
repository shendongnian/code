    MyClass o = new MyClass();
    string n = Path.GetTempFileName();
    using (FileStream s = new FileStream(n, FileMode.Create, FileAccess.Write))
    {
       o.TempStream = t;
       o.ProduceOutput();
    }
    using (FileStream s = new FileStream(n, FileMode.Open, FileAccess.Read))
    {
       o.TempStream = t;
       o.ProcessOutput();
    }
    File.Delete(n);
