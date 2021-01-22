    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1() { InitializeComponent(); }
    
            ToolTip tip = new ToolTip();
            void richTextBox1_MouseMove(object sender, MouseEventArgs e)
            {
                if (!timer1.Enabled)
                {
                    string link = GetWord(richTextBox1.Text, richTextBox1.GetCharIndexFromPosition(e.Location));
                    //Checks whether the current word i a URL, change the regex to which you want, I found it on www.regexlib.com
                    if (System.Text.RegularExpressions.Regex.IsMatch(link, @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*$"))
                    {
                        tip.ToolTipTitle = link;
                        Point p = richTextBox1.Location;
                        tip.Show(link, this, p.X + e.X,
                            p.Y + e.Y + 32, //You can change it (the 35) to the tooltip's height - controls the tooltips position.
                            1000);
                        timer1.Enabled = true;
                    }
                }
            }
    
            private void timer1_Tick(object sender, EventArgs e) //The timer is to control the tooltip, it shouldn't redraw on each mouse move.
            {
                timer1.Enabled = false;
            }
    
            public static string GetWord(string input, int position) //Extracts the whole word the mouse is currently focused on.
            {
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
        }
    }
