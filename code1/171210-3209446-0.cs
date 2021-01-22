        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) leftPressed = true;
            else if (e.Button == MouseButtons.Right) rightPressed = true;
            if (leftPressed && rightPressed)
            {
                MessageBox.Show("Hello");
                // note: 
                // the following are needed if you show a modal window on mousedown, 
                // the modal window somehow "eats" the mouseup event, 
                // hence not triggering the MouseUp event below
                leftPressed = false;
                rightPressed = false;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) leftPressed = false;
            else if (e.Button == MouseButtons.Right) rightPressed = false;
        }
