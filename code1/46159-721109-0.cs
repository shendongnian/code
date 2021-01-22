    private void button1_Click(object sender, System.EventArgs e)
    {
    	Form2 oForm2 = new Form2();
    	oForm2.MyParentForm = this;
    	if (oForm2.ShowDialog() == DialogResult.OK)
        {
    		oForm2.Dispose(); //or oForm2.Close() what you want
        }
    }
