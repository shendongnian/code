    class Model<T>
    {
        public abstract T Read(Guid ID);
    }
    
    class Appointment : Model<Appointment>
    {
        public override Appointment Read(Guid ID) { }
    }
