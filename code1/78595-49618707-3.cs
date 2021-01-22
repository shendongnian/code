    public class Default : IHttpHandler 
    {
       public void ProcessRequest (HttpContext context) 
       {
          var request = context.Request;
          var stm = request.GetBufferlessInputStream(true); //true --> disable web.config limits on request size
          if (!stm.CanRead) 
             throw new Exception("Request input stream is not readable");
          //Setup the buffer we'll be shuffling stream data into
          int bufferLength = 16 * 8040; //use a multiple of 8040 bytes, because SQL Server uses pages of 8040 bytes. And because i'm saving it into SQL Server.
          byte[] buffer = new Byte[bufferLength];
          int bytesRead;
          bytesRead = stm.Read(buffer, 0, buffer.Length);
          while (bytesRead > 0)
          {
             SavePiece(buffer, bytesRead); //whatever you want to do with it
             bytesRead = stm.Read(buffer, 0, buffer.Length);
          }
       }
       private void SavePiece(byte[] buffer, int bufferLength)
       {
          //It's all going to be multipart mime encoded nonsense.
          //Good luck!
       }
       public bool IsReusable { get { return false;}
    }
