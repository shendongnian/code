    public void Brighten(PrimaryColor pc)
    {
        AdjustPrimaryColor(pc, v => v + 5);
    }
    public void Darken(PrimaryColor pc)
    {
        AdjustPrimaryColor(pc, v => v + 5);
    }
    public void Desaturate(PrimaryColor pc)
    {
        AdjustPrimaryColor(pc, v => 0);
    }
    public void Maximize(PrimaryColor pc)
    {
        AdjustPrimaryColor(pc, v => 255);
    }
