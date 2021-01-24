    private void button2_Click(object sender, EventArgs e)
    {
        string[] cwatchers = richTextBox2Text.Split('\n');
        for (int i = 0; i < cwatchers.Length; i++)
        {
            //Get the listview item in i and add the sub item for the watchers.
            //this assumes that the list view item is created and contains two subitems so the next one to be added is the wawtchers.
            
            listView1.Items[i].SubItems.Add(cwatchers[i]);
    
            //TODO: add the rest of the sub items
        }
    }
