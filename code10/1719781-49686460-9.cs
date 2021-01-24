    public class TestClass
    {
        [Fact]
        public void MultiSensorDataTest()
        {
            var dummyTempSensor = new DummyTempSensor();
            var dummyMoveSensor = new DummyMoveSensor();
            var multiSensorData = new MultiSensorData(dummyMoveSensor, dummyTempSensor);
            Assert.Equal(10, multiSensorData.GetSensorData1());
            Assert.Equal(0.5, multiSensorData.GetSensorData2());
        }
        private class DummyTempSensor : ITemperatureSensorDataReceivable
        {
            public double GetData() => 0.5;
        }
        private class DummyMoveSensor : IMoveSensorDataReceivable
        {
            public uint GetData() => 10;
        }
    }
