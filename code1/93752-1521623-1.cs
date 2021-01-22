    using (TempFileStream t as new TempFileStream())
    {
       MyClass o = new MyClass(o);
       o.TempStream = t;
       o.ProduceOutput();
       t.Seek(0, SeekOrigin.Begin);
       o.ProcessOutput();
    }
