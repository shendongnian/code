    public Form1()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        spawnGate("not");
    }
    // This list is optional, if you easily want to find them later
    List<PictureBox> allNOTs = new List<PictureBox>();
    
    public void spawnGate(string type)
    {
        switch (type)
        {
            case "not":
                PictureBox NOT = new PictureBox();
                NOT.Width = 100;
                NOT.Height = 50;
                NOT.Image = Properties.Resources.Not_gate;
                NOT.SizeMode = PictureBoxSizeMode.Zoom;
                NOT.MouseDown += (ss, ee) =>
                {
                    // Mouse down event code here
                };
                NOT.MouseMove += (ss, ee) =>
                {
                    // Mouse move event code here
                };
                allNOTS.Add(NOT); // Optional if you easily want to find it later
                workspace.Controls.Add(NOT);
            break;
        }
    }
}
