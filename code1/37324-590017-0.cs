        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Label label1;
    //...
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataSet1.ReadXml("x2.xml");
            this.label1.Text = dataSet1.Tables[0].TableName;
            this.bindingSource1.DataSource = dataSet1.Tables[0];
            this.dataGridView1.DataSource = bindingSource1;
        }
