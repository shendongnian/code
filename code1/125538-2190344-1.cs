    [Serializable()]
    class MyCustomFlash : AxShockwaveFlashObjects.AxShockwaveFlash, ISerializable
    {
        public MyCustomFlash()
        {
        }
        public MyCustomFlash(SerializationInfo info, StreamingContext ctxt)
        {
           //dont think this is required.
            this.OcxState = (State)info.GetValue("ocxstate", typeof(State));              
        }
        #region ISerializable Members
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
           //dont think this is required.
           // info.AddValue("movie", this.Movie);
            info.AddValue("ocxstate", this.OcxState);
        }
        #endregion
    }
