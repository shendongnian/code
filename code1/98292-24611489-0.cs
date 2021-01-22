    string mystring = "122014";
      
    mystring = mystring.Substring(mystring.Length - 4);
    Response.Write(mystring.ToString());
    //output:2014
    mystring = "122014";
    string sub = mystring.Remove(mystring.Length - 4);
    Response.Write("<br>");
    Response.Write(sub.ToString());
    //output: 12
