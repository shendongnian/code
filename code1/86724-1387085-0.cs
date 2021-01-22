    public override bool Equals(object o)
    {
        if (o == null)
        {
            return false;
        }
        if (!(o is Module))
        {
            return false;
        }
        Module internalModule = o as Module;
        internalModule = internalModule.InternalModule;
        return (this.InternalModule == internalModule);
    }
