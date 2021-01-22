    public class ParserFactory
        {
            public static IParser Create(string type)
            {
                IParser parser;
                switch (type)
                {
                    case "1":
                        parser = new Parser1();
                        break;
                    case "2":
                        parser = new Parser2();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("type");
                }
    
                return parser;
            }
        }
