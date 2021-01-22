            colorCode == 4 ? Color.Yellow : Color.Brown;
            if (e.RowIndex < 0 || Grd_Cust.Rows[e.RowIndex]
               .Cells["FollowedUp"].Value == DBNull.Value)
                return;
            string colorCode = Grd_Cust.Rows[e.RowIndex].Cells["FollowedUp"].Value.ToString();
            e.CellStyle.BackColor = colorCode == "NO" ? Color.Red :         Grd_Cust.DefaultCellStyle.BackColor;
        }
