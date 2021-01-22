    public string BuildURLAndNavigate(CodeType codeType) 
    {  
        StringBuilder vURL = new StringBuilder();
 
        vURL.Append("http://some.com/nav"); 
        vURL.Append("/somepage.asp?app=myapp"); 
 
        //Build Code Type 
        switch (codeType) 
        { 
            case CodeType.Series: 
                vURL.Append("&tools=ser"); 
                break;  
            case CodeType.DataType: 
                vURL.Append("&tools=dt"); 
                break; 
        } 
 
        //build version  
        string VER_NUM = "5.0"; 
        vURL.AppendFormat("&vsn={0}", VER_NUM);          
        return vURL.ToString(); 
    } 
