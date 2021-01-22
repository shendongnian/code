    public class Car : IVehicule
    {
        private static CarControl m_control;
        public UserControl GetVehiculeControl()
        {
             if(m_control == null)
                 m_control = new CarControl();
 
             return m_control;
        }
    }
