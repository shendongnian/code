    public interface ISensor
    {
        SensorData GetData();
    }
    public class SensorData
    {
    }
    public class Sensor : ISensor
    {
        public SensorData GetData()
        {
            return new SensorData();
        }
    }
    public class SensorSimulator : ISensor
    {
        public SensorData GetData()
        {
            return new SensorData();
        }
    }
    public class SensorHost
    {
        public ISensor Sensor { get; set; }
        public void Measure()
        {
            Console.WriteLine(Sensor.GetData());
        }
    }
    public static class Program
    {
        static void Main(string[] args)
        {
            SensorHost host = new SensorHost();
            host.Sensor = new Sensor();
            // measures by real sensor
            host.Measure();
            host.Sensor = new SensorSimulator();
            // measures by sensor simulator
            host.Measure();
        }
    }
