    public class MoveSensor : IDataRecievable<uint>
    {
        public void CollectData()
        {
            //do collect logic here
        }
        public uint GetData()
        {
            //do get data
        }
    }
    public class TemperatureSensor : IDataRecievable<double>
    {
        public void CollectData()
        {
            //do collect logic here
        }
        public double GetData()
        {
            //do get data
        }
    }
