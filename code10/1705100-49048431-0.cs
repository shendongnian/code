    public interface ISensor
    {
        int GetData();
        void StopProcessing();
    }
    public class Sensor : ISensor
    {
        public int GetData()
        {
            return 0;
        }
        public void StopProcessing()
        {
            //throw new NotImplementedException();
        }
    }
    public class SensorSimulator : ISensor
    {
        public int GetData()
        {
            return 1;
        }
        public void StopProcessing()
        {
            //throw new NotImplementedException();
        }
    }
