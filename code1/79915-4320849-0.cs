    public partial class EndOfDayPackageInfo
    {
        [OnDeserialized()]
        public void Init(StreamingContext context)
        {
            _sendEmail = true;
        }
        private bool _sendEmail;
        public bool SendEmail
        {
            get
            {
                return _sendEmail;
            }
            set
            {
                _sendEmail = value;
                RaisePropertyChanged("SendEmail");
            }
        }
