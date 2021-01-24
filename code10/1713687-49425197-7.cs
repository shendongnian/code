    public class NamedSensor: Sensor
    {
        public NamedSensor(string name)
            :base(name)
        { }
    }
    public class IdSensor: Sensor
    {
        public IdSensor(int areaId, int sensorId)
            :base(areaId, sensorId)
        { }
    }
