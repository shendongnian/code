    public class BaseResponse<T> where T : BaseObj
    {
        public T value; //from object to T
        public T Get()
        {
            return value as T;
        }
        public List<T> List()
        {
            return value as List<T>;
        }
    }
