    Dispatcher.BeginInvoke(new Action(() =>
    {
        targetDT = targetDate.Text;
        targethh = Int32.Parse(targetHour.Text);
        targetmm = Int32.Parse(targetMinute.Text);
        differenceTime.Text = targetDT + "-" + targethh;
    }));
