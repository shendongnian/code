    public partial class About : System.Web.UI.Page
    {
        static int sign;
        static double num;
        static double num2;
        /* ... */
        protected void PlusBut_Click(object sender, EventArgs e)
        {
            About.num = double.Parse(AnswerBox.Text);
            AnswerBox.Text = "";
            sign = 1;
        }
    }
