       [Test]
        public void TestInput(){
        
           NetworkInputSource mockInput = mocks.CreateMock<NetworkInputSource>();
           Consumer c = new Consumer(mockInput);
        
           c.ReadAll();
        //   c.Read();
        //   c.ReadLine();
        
        }
        
        public class TcpClientAdapter : NetworkInputSource
        {
           private TcpClient _client;
           public string ReadAll()
           { 
               return new StreamReader(_tcpClient.GetStream()).ReadToEnd();
           }
    
           public string Read() { ... }
           public string ReadLine() { ... }
        }
        
        public interface NetworkInputSource
        {
           public string ReadAll(); 
           public string Read();
           public string ReadLine();
        }
