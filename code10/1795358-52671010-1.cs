    IEnumerator sendLogin()
    {
        // Creating the form
        WWWForm loginUser = new WWWForm();
        loginUser.AddField("name", fieldUsername.text);
        loginUser.AddField("password", fieldPassword.text);
    
        //Version 0 - Result: "\u001f�\b"
        WWW www = new WWW(url, loginUser);
        yield return www;
        //Debug.Log(www.text);
    
        //Decompress the data
        byte[] decompress = Decompress(www.bytes);
        //Convert to string
        string text = System.Text.ASCIIEncoding.ASCII.GetString(decompress);
        Debug.Log(text);
    }
