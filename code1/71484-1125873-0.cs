    interface IDataObjectBase<T>
        {
            void Delete();
            void Insert();
            System.Collections.Generic.List<T> Select();
            void Update();
        }
