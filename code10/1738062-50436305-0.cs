    private void textBox_KeyDown(object sender, KeyEventArgs e)
    {
        //something here to only allow "A" key to be pressed and displeyed into textbox
        if (e.Key == Key.A)
        {                
            stoper.Start();
        }
        else
            e.Handled = true;
    }
    private void textBox_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.A)
        {
            //here i stop the stopwatch to count time of pressing the key
            stoper.Stop();
            string aS = stoper.ElapsedMilliseconds.ToString();
            int aI = Convert.ToInt32(aS);
            stoper.Reset();
        }
    }
