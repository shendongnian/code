    OneOf<string, ColorName, Color> backgroundColor = getBackground(); 
    Color c = backgroundColor.Match(
        str => CssHelper.GetColorFromString(str),
        name => new Color(name),
        col => col
    );
   
