            decimal FF = 0;
            decimal BW = 0;
    
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if(dt.Rows[i]["FF"].ToString() != "")
                {
                    FF += Convert.ToDecimal(dt.Rows[i]["FF"].ToString());
                }
                if (dt.Rows[i]["BW"].ToString() != "")
                {
                    BW += Convert.ToDecimal(dt.Rows[i]["BW"].ToString());
                }     
            }
