    public override void Write(string x)
    {
         // Use whatever format you want here...
         base.Write(string.Format("{0:r}: {1}", DateTime.UtcNow, x);
    }
    public override void WriteLine(string x)
    {
         // Use whatever format you want here...
         base.WriteLine(string.Format("{0:r}: {1}", DateTime.UtcNow, x);
    }
