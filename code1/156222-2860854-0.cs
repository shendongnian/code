       public Form1()
        {
            InitializeComponent();
            rich = new RichTextBox();
            rich.Size = new Size(150, 50);
            rich.Text = "Ignoring a bug for five years does not make it a undocumented feature.";
            rich.Location = new Point(20, 20);
            rich.AutoWordSelection = false;
            this.Controls.Add(rich);
        }
    private void Form1_Load(object sender, EventArgs e)
    {
        this.BeginInvoke(new EventHandler(delegate
        {
            rich.AutoWordSelection = false;
        }));
    }
