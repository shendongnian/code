     if (samples.Any(x => x.Date == e.Day.Date))
     {
         e.Cell.BackColor = System.Drawing.Color.Orange;
         Environment.NewLine.ToString();
         e.Cell.ForeColor = System.Drawing.Color.Red;
         e.Cell.Font.Size = 9;
         e.Cell.Controls.Add(new LiteralControl("<p></p>Slot available:"));
         e.Cell.Controls.Add(new LiteralControl(samples.Where(x => x.Date == e.Day.Date).FirstOrDefault().SlotAvailable.ToString()));
         e.Cell.Controls.Add(new LiteralControl("<p></p>Pending:"));
         e.Cell.Controls.Add(new LiteralControl(samples.Where(x => x.Date == e.Day.Date).FirstOrDefault().Pending.ToString()));
     }
     else
     {
         e.Cell.Font.Size = 9;
         e.Cell.Controls.Add(new LiteralControl("<p>Slot available: 10</p>"));
         e.Cell.Controls.Add(new LiteralControl("<p></p>Pending: 0"));
     }
