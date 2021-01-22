    private bool left_down;
    private bool right_down;
    private bool both_click;
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            left_down = true;
            if (right_down)
                both_click = true;
        }
        if (e.Button == MouseButtons.Right)
        {
            right_down = true;
            if (left_down)
                both_click = true;
        }
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if (!right_down)
            {
                if (both_click)
                    //Do both-click stuff here
                else
                    //Do left-click stuff here
                both_click = false;
            }
            left_down = false;
        }
        if (e.Button == MouseButtons.Right)
        {
            if (!left_down)
            {
                if (both_click)
                    //Do both-click stuff here
                else
                    //Do right-click stuff here
                both_click = false;
            }
            right_down = false;
        }
    }
