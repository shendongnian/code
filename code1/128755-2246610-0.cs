    class Model<T>
    {
        public abstract T Read(Guid ID);
    }
    
    class Appointment : Model<Appointment>
    {
        public Appointment Read(Guid ID) { }
    }
