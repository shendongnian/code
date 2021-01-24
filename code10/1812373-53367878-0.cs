    // timer1 for key checking, recommend you to set interval 10
    private void timer1_Tick(object sender, EventArgs e) {
        // check key press with GetAsyncKeyState
        if (GetAsyncKeyState(Keys.F1) == -32768) {
            // disable timer2 
            timer2.Enabled = false;
        }
    }
    // timer2 for key pressing, recommend you to set interval 2000
    private void timer2_Tick(object sender, EventArgs e) {
        SendKeys.Send("{F1}");
    }
