    public class TempFileStream : FileStream
    {
    
        public TempFileStream(Action<string> onClose)
            : base(Path.GetTempFileName(), FileMode.OpenOrCreate, FileAccess.ReadWrite)
        {
            this.CloseDelegate = onClose;
        }
    
        protected Action<string> CloseDelegate 
        {
            get;
            set;
        }
    
        public override void Close()
        {
            base.Close();
            if (File.Exists(this.Name))
            {
                this.CloseDelegate(this.Name);
            }
        }
    
    }
