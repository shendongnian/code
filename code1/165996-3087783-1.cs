    int cells_count;
            ArrayList Header_list = new ArrayList();
            
    //wrking..
                cells_count = GridView1.HeaderRow.Cells.Count;
                for (int i = 0; i < cells_count; i++)
                {
                    Header_list.Add( GridView1.HeaderRow.Cells[i].Text );
                }
               // Label1.Text = GridView1.HeaderRow.Cells[1].Text;
                //the first colunm name
                Label1.Text = Header_list[0].ToString();
