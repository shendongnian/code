    public class Reader
    {
        public Reader Read<T>(out T t) where T : struct
        {
            var line = Console.ReadLine();
            t = GetValueFromStringRepresentation<T>(line);
            return this;
        }
    
        public Reader Read(out string str)
        {
            str = Console.ReadLine();
            return this;
        }
        //GetValueFromStringRepresentation stuff
    }
