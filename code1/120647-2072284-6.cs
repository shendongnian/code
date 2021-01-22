    namespace MyCompany.MyProduct.MyComponent
    {
        public interface IMyObjectInterface
        {
            void MyObjectMethod();
        }
        /* It's important to include this non-generic interface as a base for
         * IMyContentInterface<T> because you will be able to reference this
         * in the assembly where you load components dynamically.
         */
        public interface IMyContentInterface
        {
            Type ObjectType
            {
                get;
            }
            void MyContentMethod();
        }
        public interface IMyContentInterface<T> : IMyContentInterface
            where T : IMyObjectInterface
        {
        }
    }
