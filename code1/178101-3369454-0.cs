    public string BuildURLAndNavigate(CodeType codeType) 
    {  
        StringBuilder vURL = new StringBuilder();
 
        vURL.Append("http://some.com/nav"); 
        vURL.Append("/somepage.asp?app=myapp"); 
 
        //Build Code Type 
        vURL.Append(codeType == CodeType.Series ? "&tools=ser" : "&tools=dt");
 
        //build version  
        string VER_NUM = "5.0"; 
        vURL.AppendFormat("&vsn={0}", VER_NUM);          
        return vURL.ToString(); 
    } 
