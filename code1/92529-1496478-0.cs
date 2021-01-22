    public Control ReadControl(TextReader reader)
    {
        string controlType = ReadControlType(reader);
        string text = ReadText(reader);
        Point location = ReadLocation(reader);
        ... return the control ...
    }
