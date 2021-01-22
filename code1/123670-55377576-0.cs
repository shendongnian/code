    static void Main(string[] args)
    {
        using (Py.GIL())
        {
            dynamic foo = Py.Import("your_script_name");
        }
    }
