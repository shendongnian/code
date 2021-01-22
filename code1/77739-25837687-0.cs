You could do this by using System.Net instead of LINQ, although it would be quite messy. Just to give you an idea on how you can read parts of a http response:
    // Get the HTTP response
    string url = "http://someurl.com/myxml.xml";
    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    // Build a stream
    Stream stream = response.GetResponseStream();
    Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
    StreamReader reader = new StreamReader( stream, encode );
    // Loop the file
    Char[] read = new Char[256];
    int count = reader.Read( read, 0, 256 );
    while (count > 0) {
        String str = new String(read, 0, count);
        count = reader.Read(read, 0, 256);
    }
    response.Close();
    stream.Close();
You can use paging by adjusting the count and simultaneously searching str for XML tags.
