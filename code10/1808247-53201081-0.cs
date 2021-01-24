    char direction;
    string directions = Microsoft.VisualBasic.Interaction.InputBox("1 = Buy, 2 = Sell", "Select side", "Default", 700, 400);
    if(!string.IsNullOrEmpty(directions) && directions.Trim().Length == 1)
      direction = System.Convert.ToChar(directions);
    else {}
