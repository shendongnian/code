    public MyClass()
    {
        InitializeComponent();
        textBox1.Leave += new EventHandler(testBox1_Leave);
    }
    void testBox1_Leave(object sender, EventArgs e)
    {
      //Do Stuff
    }
