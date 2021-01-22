    [ParseChildren(true, "TestInnerText")]
    public partial class mytag : UserControl
    {
        public string TestInnerText
        {
            set
            {
                LiteralControl lc=new LiteralControl();
                lc.Text=value;
                this.Controls.Add(lc);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
