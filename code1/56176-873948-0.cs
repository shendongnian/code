        public static string GetWord(string input, int position)
        {
            if (position == input.Length) return "";
            char s = input[position];
            int sp1 = 0, sp2 = input.Length;
            for (int i = position; i > 0; i--)
            {
                char ch = input[i];
                if (ch == ' ' || ch == '\n')
                {
                    sp1 = i;
                    break;
                }
            }
            for (int i = position; i < input.Length; i++)
            {
                char ch = input[i];
                if (ch == ' ' || ch == '\n')
                {
                    sp2 = i;
                    break;
                }
            }
            return input.Substring(sp1, sp2 - sp1).Replace("\n", "");
        }
        bool flag = false;
        ToolTip tip = new ToolTip();
        void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled)
            {
                string link = GetWord(richTextBox1.Text, richTextBox1.GetCharIndexFromPosition(e.Location));
                tip.ToolTipTitle = link;
                Point p = richTextBox1.Location;
                tip.Show(link, this, p.X + e.X,
                    p.Y + e.Y + 32, //You can change it (the 35) to the tooltip height
                    1000);
                timer1.Enabled = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
