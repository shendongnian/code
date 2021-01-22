    interface IModelEntity
    {
        object Read(Guid ID);
    }
    
    class Model<T> : IModelEntity
    {
        public T Read(Guid ID)
        {
            return this.OnRead(ID); // Call the abstract read implementation
        }
        object IModelEntity.Read(Guid ID)
        {
            return this.OnRead(ID); // Call the abstract read implementation
        }
        protected abstract virtual T OnRead(Guid ID);
    }
    class Appointment : Model<Appointment>
    {
        protected override Appointment OnRead(Guid ID) { /* Do Read Stuff */ }
    }
