    private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Button Column ";
            bcol.Text = "Click Me";
            bcol.Name = "btnClickMe";
            bcol.UseColumnTextForButtonValue = true;
            dgMainGrid.Columns.Add(bcol);
            dgMainGrid.CellContentClick += DgMainGrid_CellContentClick;
        }
        private void DgMainGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                MessageBox.Show("Hi");
            }
        }
