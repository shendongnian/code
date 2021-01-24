    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        var ResetMouseEventArgs= 
            chart1.GetType().GetMethod("ResetMouseEventArgs",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
        ResetMouseEventArgs.Invoke(chart1, null);
    }
