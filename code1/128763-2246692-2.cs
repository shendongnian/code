    public class Appointment : IModel
    {
        public static Appointment Read(Guid ID)
        {
            return new Appointment()
                   {
                       ...
                   };
        }
    }
