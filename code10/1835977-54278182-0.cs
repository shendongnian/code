    public partial class Form1 : Form
    {
        private Revision rev;
        public Form1()
        {
            InitializeComponent();
            rev = new Revision("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!? *-+", "00");
            label1.Text = rev.CurrentRevision;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            rev.NextRevision();
            if (rev.CurrentRevision.Length == 4)
            {
                timer1.Stop();
                MessageBox.Show("Sequence Complete");
                // make it start back at the beginning?
                rev = new Revision("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!? *-+", "00");
                label1.Text = rev.CurrentRevision;
            }
            else
            {
                label1.Text = rev.CurrentRevision;
            }
        }
    }
    public class Revision
    {
        private string chars;
        private char[] values;
        private System.Text.StringBuilder curRevision;
        public Revision()
        {
            this.DefaultRevision();
        }
        public Revision(string validChars)
        {
            if (validChars.Length > 0)
            {
                chars = validChars;
                values = validChars.ToCharArray();
                curRevision = new System.Text.StringBuilder(values[0]);
            }
            else
            {
                this.DefaultRevision();
            }
        }
        public Revision(string validChars, string startingRevision)
            : this(validChars)
        {
            curRevision = new System.Text.StringBuilder(startingRevision.ToUpper());
            int i = 0;
            for (i = 0; i <= curRevision.Length - 1; i++)
            {
                if (Array.IndexOf(values, curRevision[i]) == -1)
                {
                    curRevision = new System.Text.StringBuilder(values[0]);
                    break;
                }
            }
        }
        private void DefaultRevision()
        {
            chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            values = chars.ToCharArray();
            curRevision = new System.Text.StringBuilder(values[0]);
        }
        public string ValidChars
        {
            get { return chars; }
        }
        public string CurrentRevision
        {
            get { return curRevision.ToString(); }
        }
        public string NextRevision(int numRevisions = 1)
        {
            bool forward = (numRevisions > 0);
            numRevisions = Math.Abs(numRevisions);
            int i = 0;
            for (i = 1; i <= numRevisions; i++)
            {
                if (forward)
                {
                    this.Increment();
                }
                else
                {
                    this.Decrement();
                }
            }
            return this.CurrentRevision;
        }
        private void Increment()
        {
            char curChar = curRevision[curRevision.Length - 1];
            int index = Array.IndexOf(values, curChar);
            if (index < (chars.Length - 1))
            {
                index = index + 1;
                curRevision[curRevision.Length - 1] = values[index];
            }
            else
            {
                curRevision[curRevision.Length - 1] = values[0];
                int i = 0;
                int startPosition = curRevision.Length - 2;
                for (i = startPosition; i >= 0; i += -1)
                {
                    curChar = curRevision[i];
                    index = Array.IndexOf(values, curChar);
                    if (index < (values.Length - 1))
                    {
                        index = index + 1;
                        curRevision[i] = values[index];
                        return;
                    }
                    else
                    {
                        curRevision[i] = values[0];
                    }
                }
                curRevision.Insert(0, values[0]);
            }
        }
        private void Decrement()
        {
            char curChar = curRevision[curRevision.Length - 1];
            int index = Array.IndexOf(values, curChar);
            if (index > 0)
            {
                index = index - 1;
                curRevision[curRevision.Length - 1] = values[index];
            }
            else
            {
                curRevision[curRevision.Length - 1] = values[values.Length - 1];
                int i = 0;
                int startPosition = curRevision.Length - 2;
                for (i = startPosition; i >= 0; i += -1)
                {
                    curChar = curRevision[i];
                    index = Array.IndexOf(values, curChar);
                    if (index > 0)
                    {
                        index = index - 1;
                        curRevision[i] = values[index];
                        return;
                    }
                    else
                    {
                        curRevision[i] = values[values.Length - 1];
                    }
                }
                curRevision.Remove(0, 1);
                if (curRevision.Length == 0)
                {
                    curRevision.Insert(0, values[0]);
                }
            }
        }
    }
