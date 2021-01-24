    byte[] Input;
    using (MemoryStream mem = new MemoryStream())
    {
        mem.Write(Input, 0, (int)Input.Length);
    
        mem.Position = 0;
    
        using (StreamReader stream = new StreamReader(mem))
        {
            ...
        }
    }
