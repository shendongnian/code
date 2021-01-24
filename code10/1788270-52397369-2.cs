    if(type == "R")
        {
            index--; //2
            //draw._rectangles.RemoveAt(index);
            dgv_Layers.Rows.RemoveAt(index);
            counter--;
            for(int i =0; i < dgv_Layers.Rows.Count; i++)
            {
                index++; //3
                dgv_Layers.Rows[i].Cells[0].Value = index; //3
            }
        }
