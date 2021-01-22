    [Serializable]
    public class Error : Exception
    {
        public string ErrorMessage { get; set; }
        public Error(SerializationInfo info, StreamingContext context) {
            if (info != null)
                this.ErrorMessage = info.GetString("ErrorMessage");
        }
        public override void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (info != null)
                info.AddValue("ErrorMessage", this.ErrorMessage);
        }
    }
