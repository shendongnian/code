    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
          {
              days = (List<int>)Session["var"];
               if (days == null) days = new List<int>();
               days.Add(Calendar1.SelectedDate.Day);
               Session["var"] = days;
               ListBox1.Items.Clear();
                  foreach (int d in days)
                  {
                    Calendar1.SelectedDates.Add(new DateTime(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month, d));
                    Calendar1.SelectedDayStyle.BackColor = System.Drawing.Color.Red;
                    ListBox1.Items.Add(d.ToString());
               }
              
          }
