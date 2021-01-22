    listView1.Items[1].UseItemStyleForSubItems = false;
    if (listView1.Items[1].SubItems[10].BackColor == Color.DarkBlue)
    {
        listView1.Items[1].SubItems[10].BackColor = Color.White;
        listView1.Items[1].SubItems[10].ForeColor = Color.Black;
    }
    else
    {
        listView1.Items[1].SubItems[10].BackColor = Color.DarkBlue;
        listView1.Items[1].SubItems[10].ForeColor = Color.White;
    }
