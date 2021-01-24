    private void Test_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dataGridView2.ColumnCount; i++)
        {
            string textBoxName = "text" + i;
            TextBox textBox = (TextBox)Controls["text0"];
            if (textBox.Text == "sunny")
            {
                //...
            }
        }
    }
