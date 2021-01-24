    public class CompositionTest
    {
        Plane plane1 = new Plane();
        Plane plane2 = new Plane();
        Car car1 = new Car();
        Car car2 = new Car();
        public CompositionTest()
        {
            
            var imotorFields = GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Where(field => typeof(IMotor).IsAssignableFrom(field.FieldType));
            foreach (var field in imotorFields)
            {
                ((IMotor)field.GetValue(this)).PressGas();
            }
        }
    }
    public interface IMotor
    {
        void PressGas();
    }
    public class Car : IMotor
    {
        public Car() { }
        public void PressGas()
        {
            //Press gas as car
        }
    }
    public class Plane : IMotor
    {
        public Plane() { }
        public void PressGas()
        {
            //Press gas as plane
        }
    }
