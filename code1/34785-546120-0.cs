    for (int i = 0; i < listView1.Items.Count; i++ )
    {
        if (listView1.Items[i].Selected)
        {
            listView1.Items[i].Remove();
            i--;
        }
    }
