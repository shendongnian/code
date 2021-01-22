    public class Car : IVehicle
    {
        public UserControl GetVehicleControl()
        {
             return new CarControl();
        }
    }
