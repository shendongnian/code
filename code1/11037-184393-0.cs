    public void DoSomething(DetailElement detailElement)
    {
        // do DetailElement specific stuff
    }
    
    public void DoSomething<G>(G elementDefinition)
        where G : ElementDefinition
    {
        // do generic ElementDefinition stuff
    }
