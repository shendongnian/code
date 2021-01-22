    string filez = GetFilename2();
    private string GetFilename2() {
    {    
        if (textBox2.TextLength.Equals("0")) return "";
 
        string inputString = textBox2.Text.ToString();    
        string last = inputString.Substring(inputString.LastIndexOf('\\') + 1);    
        return last.Split('.');    
    }   
