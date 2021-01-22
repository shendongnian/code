      private void checkBoxDate_Click(object sender, EventArgs e)
        {
            if (bindingSource != null && bindingSource.Current != null &&
                 bindingSource.Current.GetType() == typeof(MyRecord))
            {
                MyRecord a = (MyRecord)bindingSource.Current;
                if (checkBoxDate.Checked == false)
                {
                    a.Date = MYNULLDATE;
                    dateTimePicker.Enabled = false;
                }
                else
                {
                    if (a.Date == null || a.Date == MYNULLDATE)
                    {
                        dateTimePicker.Enabled = true;
                        a.Date = DateTime.Now;
                    }
                }
                bindingSource.ResetBindings(false);
            }
        }
  
