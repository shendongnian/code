     private void HoursCalculator()
        {
            var t1 = txtfromtime.Text.Trim();
            var t2 = txttotime.Text.Trim();
            var Fromtime = t1.Substring(6);
            var Totime = t2.Substring(6);
            if (Fromtime == "M")
            {
                 Fromtime = t1.Substring(5);
            }
            if (Totime == "M")
            {
                Totime = t2.Substring(5);
            }
            if (Fromtime=="PM" && Totime=="AM" )
            {
                var dt1 = DateTime.Parse("1900-01-01 " + txtfromtime.Text.Trim());
                var dt2 = DateTime.Parse("1900-01-02 " + txttotime.Text.Trim());
                var t = dt1.Subtract(dt2);
                //int temp = Convert.ToInt32(t.Hours);
                //temp = temp / 2;
                lblHours.Text =t.Hours.ToString() + ":" + t.Minutes.ToString();
            }
            else if (Fromtime == "AM" && Totime == "PM")
            {
                var dt1 = DateTime.Parse("1900-01-01 " + txtfromtime.Text.Trim());
                var dt2 = DateTime.Parse("1900-01-01 " + txttotime.Text.Trim());
                TimeSpan t = (dt2.Subtract(dt1));
                lblHours.Text = t.Hours.ToString() + ":" + t.Minutes.ToString();
            }
            else
            {
                var dt1 = DateTime.Parse("1900-01-01 " + txtfromtime.Text.Trim());
                var dt2 = DateTime.Parse("1900-01-01 " + txttotime.Text.Trim());
                TimeSpan t = (dt2.Subtract(dt1));
                lblHours.Text = t.Hours.ToString() + ":" + t.Minutes.ToString();
            }
        }
