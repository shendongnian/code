    internal class Input
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal List<Input> inputData = new List<Input>();
    internal BindingSource bindingSource;
    private void button1_Click(object sender, EventArgs e)
    {
        bindingSource = new BindingSource();
        inputData.AddRange(new [] { 
            new Input() { Id = 5476, Name = "Smith" },
            new Input() { Id = 5477, Name = "Marlin" }
        });
        bindingSource.DataSource = inputData;
        Binding tboxBind = new Binding("Text", bindingSource, "Id", false, DataSourceUpdateMode.OnPropertyChanged);
        tboxBind.Parse += (pObj, pEvt) =>
        {
            if (!int.TryParse(pEvt.Value.ToString(), out int value))
                bindingSource.ResetCurrentItem();
        };
        textBox1.DataBindings.Add(tboxBind);
        dataGridView1.DataSource = bindingSource;
    }
