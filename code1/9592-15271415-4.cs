    internal static DateTime LastBringToFrontTime { get; set; }
    private void Form1_Activated(object sender, EventArgs e)
    {
        var eventTime = DateTime.Now;
        if ((eventTime - LastBringToFrontTime).TotalMilliseconds > 500)
            Core.BringAllToFront(this);
        LastBringToFrontTime = eventTime;
    }
