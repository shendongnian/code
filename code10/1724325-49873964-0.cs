     cmd.Parameters.Add(new SqlParameter("@ssfapsclass", ssfapclass));
                cmd.Parameters.Add(new SqlParameter("@amount", currencytextboxamount.Text));
                cmd.Parameters.Add(new SqlParameter("@ssfapscode", cmbcode.Text));
                cmd.Parameters.Add(new SqlParameter("@ssfapsdesc", cmbdesc.Text));
                cmd.Parameters.Add(new SqlParameter("@term", cmbterm.Text));
