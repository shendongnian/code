    foreach(DataGridViewRow item in dgvDenominations.Rows)
                {
                   if (DateTime.Now.AddDays(7).Equals(DateTime.Parse(item.Cells["yourdateexpriedcellname"].Value.ToString())))
                   {
                       item.Cells["ExpiredStatus"].Value = "Nearing Expiry";
                       // orr message if you want
                   }
                }
