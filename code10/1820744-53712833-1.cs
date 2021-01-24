    [ServiceContract]
    public interface IRandomColoursService
    {
        [OperationContract]
        Color GenerateRandomColour(Color UsedColor);
    }
    public Color GenerateRandomColour(Color UsedColor)
    {
        List<Color> colours = new List<Color>() { 
            Color.Red, Color.Blue, Color.Green, Color.Pink, Color.Purple, Color.Black
        };
        colours.Remove(UsedColor);
        Random rand = new Random();
        return colours[rand.Next(0, colours.Count)];
    }
---
    RandomColourServiceReference.RandomColoursServiceClient ws = null;
    Color BackGroundColour { get; set; } = Color.Red;
    Color TextColour { get; set; } = Color.Black;
    public Front_End()
    {
        InitializeComponent();
        btnChangeButton.BackColor = TextColour;
        btnChangeBack.BackColor = TextColour;
        this.BackColor = BackGroundColour;
    }
    private void BtnChangeButton_Click(object sender, EventArgs e)
    {
        TextColour = ws.GenerateRandomColour(BackGroundColour);
        btnChangeButton.BackColor = TextColour;
        btnChangeBack.BackColor = TextColour;
    }
    private void BtnChangeBack_Click(object sender, EventArgs e)
    {
        BackGroundColour = GenerateRandomColour(TextColour);
        this.BackColor = BackGroundColour;
    }
