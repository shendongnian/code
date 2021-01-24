    private void button1_Click_1(object sender, EventArgs e) 
    {
        foreach (ListViewItem lstItem in listView1.Items)
        {            
            gtotal = int.Parse(lstItem.SubItems[2].Text); //Detail Column
            total = int.Parse(lstItem.SubItems[3].Text);  //Detail2 Column
            lstItem.SubItems[4].Text = gtotal + total // Sum of 2 Column of details           
        } 
     }
