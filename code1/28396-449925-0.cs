    private void btnSendRequest_Click(object sender, EventArgs e)
    {
        textBox1.Text = "";
        try
        {
            String queryString = "user=myUser&pwd=myPassword&tel=+123456798&msg=My message";
            byte[] requestByte = Encoding.Default.GetBytes(queryString);
    
            // build our request
            WebRequest webRequest = WebRequest.Create("http://www.sendFreeSMS.com/");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/xml";
            webRequest.ContentLength = requestByte.Length;
    
            // create our stram to send
            Stream webDataStream = webRequest.GetRequestStream();
            webDataStream.Write(requestByte, 0, requestByte.Length);
    
            // get the response from our stream
            WebResponse webResponse = webRequest.GetResponse();
            webDataStream = webResponse.GetResponseStream();
    
            // convert the result into a String
            StreamReader webResponseSReader = new StreamReader(webDataStream);
            String responseFromServer = webResponseSReader.ReadToEnd().Replace("\n", "").Replace("\t", "");
    
            // close everything
            webResponseSReader.Close();
            webResponse.Close();
            webDataStream.Close();
    
            // You now have the HTML in the responseFromServer variable, use it :)
            textBox1.Text = responseFromServer;
        }
        catch (Exception ex)
        {
            textBox1.Text = ex.Message;
        }
    }
