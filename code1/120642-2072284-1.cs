    namespace MyCompany.MyProduct.MyComponent
    {
        public abstract class MyAbstractObject : IMyObjectInterface
        {
            public abstract void MyObjectMethod();
        }
        public class MyObject : MyAbstractObject
        {
            public override void MyObjectMethod() { }
        }
        public abstract class MyAbstractContent<T> : IMyContentInterface<T>
            where T : MyAbstractObject
        {
            public Type ObjectType
            {
                get
                {
                    return typeof(T);
                }
            }
            public abstract void MyContentMethod();
        }
        public class MyContent : MyAbstractContent<MyObject>
        {
            public override void MyContentMethod() { }
        }
    }
