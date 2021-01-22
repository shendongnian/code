       private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(DateTimePicker))
            {
                if (((DateTimePicker)(sender)).Value == MYNULLDATE)
                {
                    ((DateTimePicker)(sender)).CustomFormat = " ";
                    checkBoxDate.Checked = false;
                }
                else
                {
                    ((DateTimePicker)(sender)).CustomFormat = "M/d/yyyy";
                    checkBoxDate.Checked = true;
                }
            }
            
        }
