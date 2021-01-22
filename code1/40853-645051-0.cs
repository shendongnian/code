        interface IType0 { void Foo(); }
        interface IType1 : IType0 { }
        interface IType2 : IType0 { }
        void Foo(IType0 type) 
        {
            type.Foo();
            return;
        }
