    // The host part of the URI is the device address, e.g. IrDAAddress.ToString(),
    // and the file part is the OBEX object name.
    
    {
        string addr = "112233445566";
        Uri uri = new Uri("obex://" + addr + "/HelloWorld2.txt");
        ObexWebRequest req = new ObexWebRequest(uri);
        using (Stream content = req.GetRequestStream()) {
            // Using a StreamWriter to write text to the stream...
            using (StreamWriter wtr = new StreamWriter(content)) {
                wtr.WriteLine("Hello World GetRequestStream");
                wtr.WriteLine("Hello World GetRequestStream 2");
                wtr.Flush();
                // Set the Length header value
                req.ContentLength = content.Length;
            }
        }
        // In this case closing the StreamWriter also closed the Stream, but ...
        ObexWebResponse rsp = (ObexWebResponse)req.GetResponse();
        Console.WriteLine("Response Code: {0} (0x{0:X})", rsp.StatusCode);
    }
