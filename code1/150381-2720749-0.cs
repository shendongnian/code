        for (int i = 0; i < comboBox1.Items.Count;i++)
        {
            if ((comboBox1.SelectedIndex)!=i)
            {
                comboBox2.Items.Add(comboBox2.Items[i]);
            }
        }
