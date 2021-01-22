    protected string get_batch_id(string session_id, string message_body)
    {
        // Declare a WebClient.
        WebClient client = new WebClient();
        // Add a User Agent Header.
        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR1.0.3705;)");
        // Add the session_id to the Query String.
        client.QueryString.Add("session_id", session_id);
        // Add the template to the Query String.
        client.QueryString.Add("template", message_body);
        // Add the callback to the Query String.
        client.QueryString.Add("callback", "3");
        // Add the deliv_ack to the Query String.
        client.QueryString.Add("deliv_ack", "1");
        // Declare the baseurl.
        string baseurl = "http://api.clickatell.com/http_batch/startbatch";
        // Open the baseurl.
        Stream data = client.OpenRead(baseurl);
        // Declare and instantiate a StreamReader to retrieve the results of executing the startbatch command.
        StreamReader reader = new StreamReader(data);
        // Parse and split the returned string into the returned_strings array.
        string[] returned_strings = reader.ReadToEnd().Split(' ');
        // Retrieve the batch_id from the (second element of the) returned_strings array.
        string batch_id = returned_strings[1].ToString();
        // Close the Stream.
        data.Close();
        // Close the Reader.
        reader.Close();
        // Return the batch_id.
        return (batch_id);
    }
