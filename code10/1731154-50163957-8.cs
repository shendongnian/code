    public bool RegexUrlWithQuestionChar(string url)
    {
        return new System.Text.RegularExpressions.Regex("[?]").IsMatch(url);
    }
---
    if(RegexUrlWithQuestionChar("www.example.com.br/area?key=235fksf&rec=fsjgsg"))
    {
        MessageBox.Show("Found"); // This show
    }
    else
    {
       MessageBox.Show("Not found");
    }
