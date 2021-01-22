    public abstract class Union<T1, T2>
    {
        public abstract int TypeSlot
        {
            get;
        }
        
        public virtual T1 AsT1()
        {
            throw new TypeAccessException(string.Format(
                "Cannot treat this instance as a {0} instance.", typeof(T1).Name));
        }
        
        public virtual T2 AsT2()
        {
            throw new TypeAccessException(string.Format(
                "Cannot treat this instance as a {0} instance.", typeof(T2).Name));
        }
        
        public static implicit operator Union<T1, T2>(T1 data)
        {
            return new FromT1(data);
        }
    
        public static implicit operator Union<T1, T2>(T2 data)
        {
            return new FromT2(data);
        }
    
        public static implicit operator Union<T1, T2>(Tuple<T1, T2> data)
        {
            return new FromTuple(data);
        }
        public static implicit operator T1(Union<T1, T2> source)
        {
            return source.AsT1();
        }
        public static implicit operator T2(Union<T1, T2> source)
        {
            return source.AsT2();
        }
    
        private class FromT1 : Union<T1, T2>
        {
            private readonly T1 data;
            public FromT1(T1 data)
            {
                this.data = data;
            }
            public override int TypeSlot 
            { 
                get { return 1; } 
            }
            public override T1 AsT1()
            { 
                return this.data;
            }
            public override string ToString()
            {
                return this.data.ToString();
            }
            public override int GetHashCode()
            {
                return this.data.GetHashCode();
            }
        }
    
        private class FromT2 : Union<T1, T2>
        {
            private readonly T2 data;
            public FromT2(T2 data)
            {
                this.data = data;
            }
            public override int TypeSlot 
            { 
                get { return 2; } 
            }
            public override T2 AsT2()
            { 
                return this.data;
            }
            public override string ToString()
            {
                return this.data.ToString();
            }
            public override int GetHashCode()
            {
                return this.data.GetHashCode();
            }
        }
        private class FromTuple : Union<T1, T2>
        {
            private readonly Tuple<T1, T2> data;
            public FromTuple(Tuple<T1, T2> data)
            {
                this.data = data;
            }
            public override int TypeSlot 
            { 
                get { return 0; } 
            }
            
            public override T1 AsT1()
            { 
                return this.data.Item1;
            }
            
            public override T2 AsT2()
            { 
                return this.data.Item2;
            }
            public override string ToString()
            {
                return this.data.ToString();
            }
            public override int GetHashCode()
            {
                return this.data.GetHashCode();
            }
        }
    }
