    public class Response
    {
        public static readonly Response Yes = new Response(1);
        public static readonly Response No = new Response(2);
        public static readonly Response Maybe = new Response(3);
    
        int value;
    
        private Response(int value)
        {
            this.value = value;
        }
    
        public static DataTable ToDataSource()
        {
            // ...
        }
    }
