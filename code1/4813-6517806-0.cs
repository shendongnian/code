    public enum Color
    {
        RED,
        GREEN,
        BLUE
    }
    
    ddColor.DataSource = Enum.GetNames(typeof(Color));
    ddColor.DataBind();
