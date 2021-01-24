    private void textBox1_MouseDown(object sender, MouseEventArgs e)
    {
        switch (e.Button)
        {
            case MouseButtons.Left:
                // Left click
                txt.Text = "left";
                break;
    
            case MouseButtons.Right:
                // Right click
                txt.Text = "right";
                break;
    
            case MouseButtons.Middle:
                // Middle click
                txt.Text = "middle";
                break;
        }
    }
