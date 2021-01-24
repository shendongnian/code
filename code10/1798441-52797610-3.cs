    public class Program
    {
        public static async Task Main(string[] args)
        {
            using(MyEntityService repo=new MyEntityService())
            {
                MyEntity myEntity=await repo.Get("foobar");
                //do stuff
            }
        }
    }
