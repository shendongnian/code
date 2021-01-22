        private static bool mouseEnteredForm
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseEnteredForm = true;
            Form.MouseLeave += Form1_MouseLeave;
            CheckMouseLocation();
        }
        
        private void Form1_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseEnteredForm = false
            CheckMouseLocation();
        }
        private static void CheckMouseLocation()
        {
            if(!mouseOverForm)
            {
                MessageBox.Show("Mouse Not Over Form!);
            }
            else if(mouseOverForm) //else if is optional. You could also use else in this case. I used else if for the sake of the example.
            {
                MessageBox.Show("Mouse Is Over Form");
            }
        }
