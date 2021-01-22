    public class MyBase<T> where T : IDataField, new()
    {
        public virtual T CreateDataField()
        {
            return new T();
        }
        public virtual T GetDataField()
        {
            return this._DataField;
        }
    }
    public class MyComplexBase : MyBase<ComplexDataField>
    {
       ...
    }
