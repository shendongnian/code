    public class Response
    {
        public dynamic this[object Key]
        {
            get
            {
                if(Key is int)
                {
                   return "Hello";
                }
                else
                {
                    return new Response();
                }
            }
        }
    }
