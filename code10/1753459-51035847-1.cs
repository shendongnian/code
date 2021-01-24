     public class AnotherClass
    {
        Iinterface c; //I removed the default new since it will get assigned in constructor     
        public AnotherClass(Iinterface obj)
        {
           c = obj;
        }
        public async Task<bool> ExecuteData()
        {
            var result = await c.RetrieveFromDataBase();
            if (result)
            {
                //do some calculation
            }
            return true;
        }
    }
