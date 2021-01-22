        public class TestService : ITestService {
            
            public XElement DoWork(string myId) {
    
                return new XElement("results", new XAttribute("myId", myId ?? ""));
            }
        }
