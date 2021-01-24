    namespace AWSLambda2 {
    
        public class Input {
            public string name { get; set; }
            public string email { get; set; }
        }
    
        public class Function {
            public string FunctionHandler(SampleClass input) {
                var data = input.data;
                var user = input.input;
                return user.name?.ToUpper()+", "+user.email?.ToUpper()+", "+data; 
            }
        }
    }
