    using System.Net;
    using System.IO;
    using System.Text;
        
    WebRequest request = WebRequest.Create("url here");
    WebResponse response = request.GetResponse();
    
    string html;
    using (Stream stream = response.GetResponseStream())
    {
        
        int index = -1, currentByte = 0;
        byte[] buffer = new byte[response.ContentLength];
        while ((currentByte = stream.ReadByte()) > -1)
        {
            if(currentByte > 0) buffer[++index] = (byte)currentByte;
        }
    
        html = Encoding.ASCII.GetString(buffer, 0, index + 1);
    }
