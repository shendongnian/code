    public string BuildURLAndNavigate(CodeType codeType)
    {    
        string vURL = "http://some.com/nav/somepage.asp?app=myapp&tools={0}&vsn={1}"; 
        string codevalue = "";
        //Build Code Type
        switch (codeType)
        {
        case CodeType.Series:
            codevalue = "ser";
            break; 
        case CodeType.DataType:
            codevalue = "dt";
            break;
        }
    
        //build version 
        string version = "5.0";
        return string.Format(vURL, codevalue, version);
        }
    }
