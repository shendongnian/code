    // declare a form scoped variable to hold a reference
    // to the run-time created DataGridview
    private DataGridView RunTimeCreatedDataGridView;
    // sample of creating the DataGridView at run-time
    // and adding to the Controls collection of a Form
    // and positioning and sizing
    // fyi: the Form used here is sized 800 by 600
    private void button1_Click(object sender, EventArgs e)
    {
        RunTimeCreatedDataGridView= new DataGridView();
        RunTimeCreatedDataGridView.Size = new Size(300, 542);
        RunTimeCreatedDataGridView.Location = new Point(10,12);
        this.Controls.Add(RunTimeCreatedDataGridView);
    }
