    public class GenericService
    {
        public ReturnObject<T> GetResult<T>() 
            where T : new()
        {
            return new ResultService<T>.Instance.GetGoodResult(new T());
        }
    }
