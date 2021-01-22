    public class MyDateTimeControl : DateTimeControl
    {
        protected override void Render(HtmlTextWriter output)
        {
            DropDownList minuteControl = null;
            string[] newMinutesRange = new string[] { "00", "15", "30", "45" };
            string[] newMinutesRangeExt = new string[] { "00", "15", "30", "45", "" };
            int index = 0;
            int selectedMinutes;
            try
            {
                if (!this.DateOnly && this.Controls.Count == 4)
                {
                    minuteControl = (DropDownList)this.Controls[2];
                }
            }
            catch { }
            if (minuteControl != null && !this.DateOnly)
            {
                selectedMinutes = Convert.ToInt32(minuteControl.SelectedValue);
                if (selectedMinutes % 15 > 0)
                {
                    index = 4;
                    newMinutesRangeExt.SetValue(selectedMinutes.ToString(), index);
                    newMinutesRange = newMinutesRangeExt;
                }
                else
                {
                    index = selectedMinutes / 15;
                }
           
                minuteControl.Items.Clear();
                minuteControl.DataSource = newMinutesRange;
                minuteControl.DataBind();
                minuteControl.SelectedIndex = index;
            }
            
            base.Render(output);            
        }
    }
