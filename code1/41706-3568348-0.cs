        int maxLC = 1; //maxLineCount - should be public
        private void rTB_KeyUp(object sender, KeyEventArgs e)
        {
            int linecount = rTB.GetLineFromCharIndex( rTB.TextLength ) + 1;
            if (linecount != maxLC)
            {
                tB_line.Clear();
                for (int i = 1; i < linecount+1; i++)
                {
                    tB_line.AppendText(Convert.ToString(i) + "\n");
                }
                maxLC = linecount;
            }
        }
