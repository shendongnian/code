    public Foo(IEnumerable<IConsole> consoles)
    {
        this.consoles = consoles; 
    }
    public void WriteStuff(string stuff)
    {
        foreach(var console in consoles)
        {
            console.WriteLine(stuff);
        }
    }
