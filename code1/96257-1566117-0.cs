    protected void Page_Load(object sender, EventArgs e)
    {
        string a = "12345678901234567890123456789012345";
        TextBox1.Text = a;
        TextBox2.Text = BreakStringIntoLinesVer2(a, 10);
    }
    string BreakStringIntoLinesVer2(string s, int lineWidth)
    {
        StringBuilder sb = new StringBuilder(s);
        int last = (sb.Length % lineWidth == 0) ? sb.Length - lineWidth : sb.Length - (sb.Length % lineWidth);
        for (int i = last; i > 0; i -= lineWidth)
        {
            sb.Insert(i, Environment.NewLine);
        }
        return sb.ToString();
    }
