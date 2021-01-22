            for (int i = 0; i < counter; i++)
            {
                if (i == counter-1)
                {
                    //this is where your LAST LINE code goes
                    //row.DefaultCellStyle.BackColor = Color.Yellow;
                    gridEstimateSales.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    //this is your normal code NOT LAST LINE
                    //row.DefaultCellStyle.BackColor = Color.Red;
                    gridEstimateSales.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
