    // Make the class generic
    public class ResponseObject<T> {
        public T Data { get; set }
        public Boolean Success { get; set; }
        public string Message { get; set; } 
    }
    // Use generic methods to access the property
    public class ResponseObject {
        private object data;
        public T GetData<T>() {
            return (T)data;
        }
        public void SetData<T>(T newData) {
            data = newData;
        }
        public Boolean Success { get; set; }
        public string Message { get; set; } 
    }
