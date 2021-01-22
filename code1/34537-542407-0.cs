    void listView1_Resize(object sender, EventArgs e)
        {
            listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
           
        }
