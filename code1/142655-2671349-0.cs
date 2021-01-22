      private void listView1_Refresh()
        {
           
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].BackColor = Color.Red;
                for (int j = 0; j < existingStudents.Count; j++)
                    if (listView1.Items[i].ToString().Contains(existingStudents[j]))
                    {
                        listView1.Items[i].BackColor = Color.Green;
                    }
            }
