    public Form1()
    {
        InitializeComponent();
        Panel p = new Panel()
        {
            BackColor = Color.PowderBlue,
            Location = new Point(10, 10)
        };
        p.Controls.Add(new Label()
            {
                Text = "Hello",
                BackColor = Color.PaleGreen,
                Location = new Point(20, 20)
            });
        p.Controls.Add(new Button()
        {
            Text = "Woof",
            BackColor = Color.Orchid,
            Location = new Point(60, 60)
        });
        this.Controls.Add(p);
    }
