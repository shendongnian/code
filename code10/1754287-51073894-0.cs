    public abstract class Car : MonoBehaviour { }
    public class Jeep : Car { }
    public class Ferrari : Car { }
    public class CarHolder : MonoBehaviour
    {
        public List<Car> Cars;
    }
