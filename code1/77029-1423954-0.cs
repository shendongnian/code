        public class Request
        {
            //...
        }
        public class RequestCreatedEventArgs : EventArgs
        { 
            Request Request {get; set;} 
        } 
        
        //=======================================
        //You must have sender as a first argument
        //=======================================
        public delegate void RequestCreatedEventHandler(object sender, RequestCreatedEventArgs e); 
        public interface IRepository
        {
            void Save(Request request);
            event RequestCreatedEventHandler Created;
        }
        [TestMethod]
        public void Test()
        {
            var repository = new Mock<IRepository>(); 
            Request request = new Request();
            repository.Setup(a => a.Save(request)).Raises(a => a.Created += null, new RequestCreatedEventArgs());
            
            bool eventRaised = false;
            repository.Object.Created += (sender, e) =>
            {
                eventRaised = true;
            };
            repository.Object.Save(request);
            Assert.IsTrue(eventRaised);
        }
