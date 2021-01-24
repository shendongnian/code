    >   string URI = "http://172.18.1.57:8080/webdesktop/APIExecutor";
    >                 string myParameters = "inXml=<?xml version='1.0'?><WMConnect_Input><Option>WMConnect</Option><EngineName>uat</EngineName><ApplicationInfo>172.18.1.57</ApplicationInfo><Participant><Name>test1234</Name><Password>test1234</Password>	<Scope></Scope>	<UserExist>Y</UserExist>	<Locale>en-US</Locale>	<ParticipantType>U</ParticipantType></Participant></WMConnect_Input>";
    > 
    > 
    >                 HttpWebRequest req = (HttpWebRequest)System.Net.WebRequest.Create(URI);
    >                 req.Method = "POST";
    >                 req.ContentType = "application/x-www-form-urlencoded";
    >                 byte[] bytes = System.Text.Encoding.ASCII.GetBytes(myParameters);
    >                 req.ContentLength = bytes.Length;
    >                 System.IO.Stream os = req.GetRequestStream();
    >                 os.Write(bytes, 0, bytes.Length); //Push it out there
    >                 os.Close();
    >                 using (HttpWebResponse response = req.GetResponse() as System.Net.HttpWebResponse)
    >                 {
    >                     using (Stream st = response.GetResponseStream())
    >                     {
    >                         StreamReader str = new StreamReader(st, System.Text.Encoding.UTF8);
    >                         var res = str.ReadToEnd();
    >                     }
    >                 }
