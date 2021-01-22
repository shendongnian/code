    public interface Example : MarshalByRefObject, IExampleProxy
    {
        public string HelloWorld( string name )
        {
            return $"Hello '{ name }'";
        }
    }
