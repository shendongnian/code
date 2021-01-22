    interface IComponentDataReader 
    {
        object GetData();
    }
    abstract class AbstractComponent
    {
        private IComponentDataReader dataReader;
        public AbstractComponent(IComponentDataReader dataReader)
        {
            this.dataReader = dataReader;
        }
        protected object GetData()
        {
            return dataReader.GetData();
        }
    }
    class Sensor : AbstractComponent
    {
        public Sensor(IComponentDataReader dataReader)
            : base(dataReader)
        {
        }
        public void DoSomethingThatRequiresData()
        {
            object data = GetData();
            // do something
        }
    }
    class SensorDataReader : IComponentDataReader
    {
        public object GetData()
        {
            // read your data
            return data;
        }
    }
    class MyApplication
    {
        public static void Main(string[] args)
        {
            Sensor sensor = new Sensor(new SensorDataReader());
            sensor.DoSomethingThatRequiresData();
        }
    }
