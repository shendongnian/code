    private async void button1_Click(object sender, EventArgs e) 
    {
        DataTable table = null;
        //Load data
        this.Text = "Loading ...";
        await Task.Run(async () => {
            await Task.Delay(2000); //Simulating a delay for loading data
            table = new DataTable();
            table.Columns.Add("C1");
            for (int i = 0; i < 10000; i++)
                table.Rows.Add(i.ToString());
        });
        this.Text = "Load data successfully.";
        //Show the other form
        var f = new Form();
        var tree = new TreeView();
        tree.Dock = DockStyle.Fill;
        f.Controls.Add(tree);
        f.Show();
        //Load Tree
        f.Text = "Loading tree...";
        await Task.Run(async () => {           
            await Task.Delay(2000); //Simulating a delay for processing
            Invoke(new Action(() => { tree.BeginUpdate(); }));
            foreach (DataRow row in table.Rows) {
                //DO NOT processing using invoke, just call UI code in INvoke.
                Invoke(new Action(() => { tree.Nodes.Add(row[0].ToString()); }));
            }
            Invoke(new Action(() => { tree.EndUpdate(); }));
        });
        f.Text = "Load tree successfully.";
    }
