    public class GenericService
    {
        public ReturnObject<T> GetResult<T>() 
            where T : new()
        {
            return new ResultService<T>().GetGoodResult(new T());
        }
    }
