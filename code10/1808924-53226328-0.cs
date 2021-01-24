    public class SerialPortSettingView : IDisposable
    {
        private FileStream _fileStream;
        public SerialPortSettingView()
        {
            _fileStream = new FileStream("somefile.txt", FileMode.Open);
        }
        public void Dispose()
        {
            _fileStream?.Close();
        }
    }
