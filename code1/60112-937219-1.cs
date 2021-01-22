    using System.Linq; // Required for the .Contains call below:
    ...
    private EventHandler foo;
    public event EventHandler Foo
    {
        add
        {
            if (foo == null || !foo.GetInvocationList().Contains(value))
            {
                foo += value;
            }
        }
        remove
        {
            foo -= value;
        }
    }
