    public class MyClass {
        private readonly IAmazonS3 client;
        
        public MyClass(IAmazonS3 client) {
            this.client = client;
        }
        
        //...
    }
    
