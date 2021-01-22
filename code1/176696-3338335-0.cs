    private void OnPostInfoClick(object sender, System.EventArgs e)
    {
        string strId = UserId_TextBox.Text;
        string strName = Name_TextBox.Text;
        ASCIIEncoding encoding=new ASCIIEncoding();
        string postData="userid="+strId;
        postData += ("&username="+strName);
        byte[]  data = encoding.GetBytes(postData);
        // Prepare web request...
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://localhost/MyIdentity/Default.aspx");
        myRequest.Method = "POST";
        myRequest.ContentType="application/x-www-form-urlencoded";
        myRequest.ContentLength = data.Length;
        Stream newStream=myRequest.GetRequestStream();
        
        // Send the data.
        newStream.Write(data,0,data.Length);
        newStream.Close();
    }
