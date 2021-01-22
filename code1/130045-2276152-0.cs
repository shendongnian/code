    // Hex to Control Color
    var myColor = "#[color from database]";
    var myControlColor = System.Drawing.ColorTranslator.FromHtml(myColor);
    // Control Color to Hex
    var colorBlue = System.Drawing.Color.Blue;
    var hexBlue = System.Drawing.ColorTranslator.ToHtml(colorBlue);
