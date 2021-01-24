    interface IResponseObject {
        object DataObj { get; set }
        Type ObjType { get; }
        bool Success { get; set; }
        string Message { get; set; } 
    }
    public class ResponseObject<T> {
        public T Data { get; set }
        public ObjType => typeof(T);
        public DataObj {
            get => Data;
            set => Data = value;
        }
        public Boolean Success { get; set; }
        public string Message { get; set; } 
    }
