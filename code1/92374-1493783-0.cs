    string Filter(string input, SomeType item, Func<SomeType, string> extract)
    {
        if (!String.IsNullOrEmpty(input))
        {
            if (item == null) return ",";
            else return "," + extract(item);
        }
    }
    
    _gridModel.Header += Filter(_gridModel.Header, item, i => i.Header);
    _gridModel.Width += Filter(_gridModel. Width, item, i => i.Width);
    _gridModel.Align += Filter(_gridModel.Align, item, i => i.Align);
    // etc...
