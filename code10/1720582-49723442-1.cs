    public Toolbox(params Tool[] tool)
    {
        foreach (Tool t in tool)
        {
            if (t is Hammer)
            {
                Hammer hammer = t as Hammer;
                .....
            }
            if (t is Screwdriver)
            {
                Screwdriver screwdriver = t as Screwdriver;
                .......
            }
        }
    }
