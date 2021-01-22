        void richTextBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                //Handle mouse move upwards
                if (richTextBox1.SelectionStart > 10)
                {
                    richTextBox1.SelectionStart -= 10;
                    richTextBox1.ScrollToCaret();
                }
            }
            else
            {
                //Mouse move downwards.
                richTextBox1.SelectionStart += 10;
                richTextBox1.ScrollToCaret();
            }
        }
