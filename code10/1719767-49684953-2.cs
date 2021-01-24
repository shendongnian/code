    public class DatabaseProxy {
        public void StoreInt(int value) { ... }
        public void StoreDouble(double value) { ... }
    }
    public interface Data {
        void StoreData(DatabaseProxy proxy);
    }
    public class IntData : Data {
        private int _value;
        public IntData(int value) {
            _value = value;
        }
        public void StoreData(DatabaseProxy proxy) {
            proxy.StoreInt(_value);
        }
    }
    public class DoubleData : Data {
        private double _value;
        public DoubleData(double value) {
            _value = value;
        }
        public void StoreData(DatabaseProxy proxy) {
            proxy.StoreDouble(_value);
        }
    }
