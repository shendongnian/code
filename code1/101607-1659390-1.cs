    public BindingSource Source { get; set; }
    public void Form2_Load(object sender, EventArgs e)
    {       
        idTextBox.DataBindings.Add("Text", Source, "id");
        descriptionTextBox.DataBindings.Add("Text", Source, "description")
    }
