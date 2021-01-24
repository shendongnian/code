    public Form1()
    {
        InitializeComponent();
        using (SamenEntities c = new SamenEntities())
        {
            comboBox6.DataSource = c.sabt_como_tahsili.ToList();
            comboBox6.ValueMember = "id_vaziat_tahsili";
            comboBox6.DisplayMember = "name_vaziat_tahsili";
        }
    }
