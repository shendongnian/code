    class DalBase<T> : IEnumerable<T> where T: ReplicatedBaseType
    {
        public IEnumerator<T> GetEnumerator() {throw new NotImplementedException();}
        IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }
    }
    class DocumentTemplate
    {
        IEnumerable<ReplicatedBaseType> BaseCollection;
        DocumentTemplate()
        {
            BaseCollection = new DalBase<NewType>(); // Error in this line. It seems this is not possible
        }
    }
