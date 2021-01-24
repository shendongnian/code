    List<PictureBox> NOT = new List<PictureBox>();
    Point startPoint = new Point();
    
    public Form1()
    {
        InitializeComponent();
        Drag();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        spawnGate();
    }
    
    public void spawnGate()
    {
        var pictureBox = new PictureBox()
        {
            Width = 100,
            Height = 50,
            Image = Properties.Resources.Not_gate,
            SizeMode = PictureBoxSizeMode.Zoom       
        }
        
        Drag(pictureBox);
        
        NOT.Add(pictureBox);
        
        workspace.Controls.Add(pictureBox);
    }
    
    public void Drag(PictureBox pictureBox)
    {
        pictureBox.MouseDown += (ss, ee) => 
        {
            if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                startPoint = Control.MousePosition;
        };
        
        pictureBox.MouseMove += (ss, ee) =>
        {
            if (ee.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point temp = Control.MousePosition;
                Point res = new Point(startPoint.X - temp.X, startPoint.Y - temp.Y);
    
                pictureBox.Location = new Point(pictureBox.Location.X - pictureBox.X, pictureBox.Location.Y - res.Y);
    
                startPoint = temp;
            }
        };
    }
