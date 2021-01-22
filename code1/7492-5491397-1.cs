    for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string vr;
                vr = GridView2.Rows[i].Cells[4].Text; // here you go vr = the value of the cel
                if (vr  == "0") // you can check for anything
                {
                    GridView2.Rows[i].Cells[4].Text = "Done";
                    // you can format this cell 
                }
            }
