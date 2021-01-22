    public class Car : IVehicule
    {
        public UserControl GetVehiculeControl()
        {
             return new CarControl();
        }
    }
