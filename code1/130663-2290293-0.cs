    public MyColours GetColours(string colour)
    {
        foreach (MyColours mc in Enum.GetNames(typeof(MyColours))) {
            if (mc.ToString().Contains(colour)) {
                return mc;
            }
        }
        return MyColours.Red; // Default value
    }
