    public static class TypeEnumerator
    {
        public class TypeEnumeratorException : Exception
        {
            public Type unknownType { get; private set; }
            public TypeEnumeratorException(Type unknownType) : base()
            {
                this.unknownType = unknownType;
            }
        }
        public enum TypeEnumeratorTypes { _int, _string, _Foo, _TcpClient, };
        private static Dictionary<Type, TypeEnumeratorTypes> typeDict;
        static TypeEnumerator()
        {
            typeDict = new Dictionary<Type, TypeEnumeratorTypes>();
            typeDict[typeof(int)] = TypeEnumeratorTypes._int;
            typeDict[typeof(string)] = TypeEnumeratorTypes._string;
            typeDict[typeof(Foo)] = TypeEnumeratorTypes._Foo;
            typeDict[typeof(System.Net.Sockets.TcpClient)] = TypeEnumeratorTypes._TcpClient;
        }
        /// <summary>
        /// Throws NullReferenceException and TypeEnumeratorException</summary>
        /// <exception cref="System.NullReferenceException">NullReferenceException</exception>
        /// <exception cref="MyProject.TypeEnumerator.TypeEnumeratorException">TypeEnumeratorException</exception>
        public static TypeEnumeratorTypes EnumerateType(object theObject)
        {
            try
            {
                return typeDict[theObject.GetType()];
            }
            catch (KeyNotFoundException)
            {
                throw new TypeEnumeratorException(theObject.GetType());
            }
        }
    }
