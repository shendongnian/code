    public class ApiRepo
    {
        static private object theLock = new object();
        private IApi api;
    
        public ApiRepo()
        {
            api=new Api("url");
        }
    
        public IEnumerable<MyDto> GetItems()
        {
            IEnumerable<ApiDto> apiDtos = null;
            lock(theLock)
            {
                apiDtos = api.GetNonThreadSafeItems();
            }
            foreach(var apiDto in apiDtos)
            {
               var myDto = new MyDto(apiDto.Name);  
               yield return myDto;
            }
        }
    }
