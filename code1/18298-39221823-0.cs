            DataTable dtTemp=new DataTable();
            for (int k = 0; k < GridView2.Rows.Count; k++)
            {
                string roomno = GridView2.Rows[k].Cells[1].Text;
                DataTable dtx = GetRoomDetails(chk, roomno, out msg);
                if (dtx.Rows.Count > 0)
                {
                    dtTemp.Merge(dtx);
                    dtTemp.AcceptChanges();
                  
                }
            }
