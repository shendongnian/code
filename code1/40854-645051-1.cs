        interface IType0 { void Foo(); }
        interface IType1 : IType0 { }
        interface IType2 : IType0 { }
        void ConditionalCall(IType0 type, bool cond) 
        {
            if (Conditional(cond))
                type.Foo();
            return;
        }
