    using System.Text.RegularExpressions;
    ...
    protected void Button1_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
    
        Regex regexObj = new Regex(@"(?<left>\w+)(\W+)(?<right>\w+)");
        Match matchResults = regexObj.Match(this.TextBox1.Text);
        while (matchResults.Success)
        {
            string left = matchResults.Groups["left"].Value;
            string right = matchResults.Groups["right"].Value;
            sb.AppendFormat("{0} = {1}{2}", right, left, Environment.NewLine);
            matchResults = matchResults.NextMatch();
        }
    
        this.TextBox2.Text = sb.ToString();
    }
