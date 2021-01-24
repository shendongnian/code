    private void AddGroupBoxAndLables()
    {
        GroupBox groupBox1 = new GroupBox();
        groupBox1.SetBounds(50, 50, 300, 200);
        this.Controls.Add(groupBox1);
        Label lblCompleted = new Label { Name = "lblCompleted", Text = "Completed" };
        lblCompleted.Location = new Point(20, 20);
        groupBox1.Controls.Add(lblCompleted);
        Label valCompleted = new Label { Name = "valCompleted" };
        valCompleted.Location = new Point(80, 20);
        groupBox1.Controls.Add(valCompleted);
        Label lblInProgress = new Label { Name = "lblInProgress", Text = "In Progress" };
        lblInProgress.Location = new Point(20, 60);
        groupBox1.Controls.Add(lblInProgress);
        Label valInProgress = new Label { Name = "valInProgress" };
        valInProgress.Location = new Point(80, 60);
        groupBox1.Controls.Add(valInProgress);
    }
