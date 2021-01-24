    private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
    {
        RunOnUiThread(() =>
        {
            var lab_seconds = FindViewById<TextView>(Resource.Id.textView_seconds);
            lab_seconds.Text = (Int32.Parse(lab_seconds.Text) -1).ToString();
         });
    }
