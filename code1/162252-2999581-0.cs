    using System.Text.RegularExpressions;
    
    Match m = Regex.Match(this.textBox1.Text, "<style type=\"text/css\">(.*?)</style>", RegexOptions.Singleline);
    if (m.Success)
    {
        string css = m.Groups[1].Value;
        //do stuff
    }
