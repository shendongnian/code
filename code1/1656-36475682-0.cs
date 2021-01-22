        public class MappingException : Exception
        {
            public MappingException() { }
            public MappingException(string msg) : base(msg) { }
            public MappingException(string msg, Exception inner) : base(msg, inner) { }
        }
