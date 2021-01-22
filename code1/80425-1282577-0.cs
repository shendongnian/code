    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            bool PreCheck = chkPrecheck.Checked;
            bool NoThrow = chkNoThrow.Checked;
            int divisor = (chkZero.Checked ? 0 : 1);
            int Iterations =  Convert.ToInt32(txtIterations.Text);
            int i = 0;
            ExceptionTest x = new ExceptionTest();
            int r = -2;
            int stat = 0;
            
            for(i=0; i < Iterations; i++)
            {
                try
                {
                    r = x.TryDivide(divisor, PreCheck, NoThrow);
                }
                catch
                {
                    stat = -3;
                }
            }
            DateTime stop = DateTime.Now;
            TimeSpan elapsed = stop - start;
            txtTime.Text = elapsed.TotalMilliseconds.ToString();
            txtReturn.Text = r.ToString();
            txtStatus.Text = stat.ToString();
        }
    }
 
    class ExceptionTest
    {
        public int TryDivide(int quotient, bool precheck, bool nothrow)
        {
            if (precheck)
            {
                if (quotient == 0)
                {
                    if (nothrow)
                    {
                        return -9;
                    }
                    else
                    {
                        throw new DivideByZeroException();
                    }
                }
            }
            else
            {
                try
                {
                    int a;
                    a = 1 / quotient;
                    return a;
                }
                catch
                {
                    if (nothrow)
                    {
                        return -9;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return -1;
        }
    }
