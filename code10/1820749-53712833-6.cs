    public Color GenerateRandomColour(List<Color> UsedColor)
    {
        List<Color> colours = new List<Color>() { 
            Color.Red, Color.Blue, Color.Green, Color.Pink, Color.Purple, Color.Black
        };
        List<Color> AvailableColours = colours.Except(UsedColor).ToList();
        Random rand = new Random();
        return AvailableColours[rand.Next(0, AvailableColours.Count)];
    }
---
    Color BackGroundColour { get; set; } = Color.Black;
    Color TextColour { get; set; } = Color.Red;
    Color AnotherColour { get; set; } = Color.Green;
    private void BtnChangeButton_Click(object sender, EventArgs e)
    {
        List<Color> UsedColors = new List<Color>() { BackGroundColour, AnotherColour };
        TextColour = ws.GenerateRandomColour(UsedColors);
        btnChangeButton.BackColor = TextColour;
        btnChangeBack.BackColor = TextColour;
    }
    //(...)
