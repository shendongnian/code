    class MyModbusController
    {
        IProgress<ModbusData> _modbusProgress;
        public MyModbusController(IProgress<ModbusData> progress)
        {
            _modbusProgress=progress;
        }
        public void Modbus_Request_Event(...)
    }
