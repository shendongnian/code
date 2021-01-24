    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                
                string json = @"{
                    'data': {
                            'human': {
                                'name': 'Luke Skywalker',
                                'height': 5.6430448
                            }
                        }
                    }
                ";
    
                A a = new A()
                {
                    Data = json,
                    Error = null
                };
                
                dynamic dyn = JsonConvert.DeserializeObject(a.Data);
                var data = dyn["data"];
                var human = data["human"];
                var name = human["name"].Value;
                
                Console.WriteLine(name);
            }
        }
        
        public class A
        {
            public dynamic Data;
            public Error Error;
        }
        
        public class Error
        {
        }
    }
