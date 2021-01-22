    public abstract class BIWebServiceResult<T>
    {
        public T Data { get; set; }
    
        public delegate StatusCode StringToStatusCode(string Input);
    
        public abstract void SetData(string Input, StringToStatusCode StringToError);
    }
