    public interface Sensor {
        Data GetData();
    }
    public interface Data {
        void Display();
    }
    
    public class IntData : Data {
        public void Display() { ... }
    }
    public class DoubleData : Data {
        public void Display() { ... }
    }
    public class MoveSensor : Sensor {
        public IntData GetData() {
            // ... return IntData ...
        }
    }
    public class TemperatureSensor : Sensor {
        public DoubleData GetData() {
            // ... return DoubleData ...
        }
    }
