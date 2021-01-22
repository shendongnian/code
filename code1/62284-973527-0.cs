    public class MyDateTimeControl : DateTimeControl
    {
        protected override void Render(HtmlTextWriter output)
        {
            string[] newMinutesRange = new string[] { "00", "15", "30", "45" };
            string[] newMinutesRangeExt = new string[] { "00", "15", "30", "45", "" };
            int index = 0;
            if (this.SelectedDate.Minute % 15 > 0)
            {
                index = 4;
                newMinutesRangeExt.SetValue( this.SelectedDate.Minute.ToString(), index);
                newMinutesRange = newMinutesRangeExt;
            }
            else
            {
                index = this.SelectedDate.Minute / 15;
            }
            DropDownList minuteControl = (DropDownList)this.Controls[2];
            if (minuteControl != null && !this.DateOnly)
            {
                minuteControl.Items.Clear();
                minuteControl.DataSource = newMinutesRange;
                minuteControl.DataBind();
                minuteControl.SelectedIndex = index;
            }
            
            base.Render(output);            
        }
    }
