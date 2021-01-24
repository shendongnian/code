    public class ExportRecords
    {
        public delegate void ExportRecordsHandler(int percentage);
        public event ExportRecordsHandler ExportRecordsProgressChanged;
        public void Execute()
        {
             //Executes your whole Process
             MakeReport(); //Reports Progress up to  25%
             MakeEmail();  //Reports Progress up to  75%
             SendEmail();  //Reports Progress up to 100%
        }
        public void MakeReport()
        {
             //some logic
             ExportRecordsProgressChanged?.Invoke(25);
        }
        public void MakeEmail()
        {
            //some logic
            ExportRecordsProgressChanged?.Invoke(75);
        }
    }
