    public class Car : IVehicle
    {
        private static CarControl m_control;
        public UserControl GetVehicleControl()
        {
             if(m_control == null)
                 m_control = new CarControl();
 
             return m_control;
        }
    }
