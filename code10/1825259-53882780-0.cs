            for (int i = 0; i < dgv_us.Rows.Count(); i++)
            {
               string obs = dgv_uc.Rows[i].Cells["Observed(Sec)"].Value.ToString();
               listObs.Add(obs);
            }
