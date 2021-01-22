    public void MyMethod ()
    {
        // both can throw IOException
        try { foo(); } catch { throw; }
        try { bar(); } catch(E) {throw new Exception(E.message); }
    }
    (...)
    try {
        MyMethod ();
    } catch (IOException ex) {
        Console.WriteLine ("Error with I/O"); // [1]
    } catch (Exception ex) {
        Console.WriteLine ("Other error");    // [2]
    }
