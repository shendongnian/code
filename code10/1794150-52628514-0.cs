    public class ModbusData
    {
        public byte Fc {get; set;}
        public short StartAddress {get; set;}
        public short NumOfPoints {get; set;}
    }
    public class MyForm : ...
    {
        IProgress<ModbusData> _modbusProgress;
        public MyForm()
        {
            __modbusProgress=new Progress<ModbusData>(ReportProgress);
        }
        public void ReportProgress(ModbusData data)
        {
            listBox1.Items.Add(data.fc1.ToString()); 
            listBox1.Items.Add(dta.StartAddress1.ToString()); 
            listBox1.Items.Add(data.NumOfPoints1.ToString()); 
        }
