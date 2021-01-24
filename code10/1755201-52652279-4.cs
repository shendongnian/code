    [Serializable]
    public class OurAdApiException : OurBaseWebException {
        /// <summary>The result of the action in Active Directory </summary>
        public AdActionResults AdResult { get; set; }
        /// <summary>The result of the action in LDS </summary>
        public AdActionResults LdsResult { get; set; }
        // Other constructors snipped...
        public OurAdApiException(SerializationInfo info, StreamingContext context) : base(info, context) {
            try {
                AdResult  = (AdActionResults) info.GetValue("AdResult",  typeof(AdActionResults));
                LdsResult = (AdActionResults) info.GetValue("LdsResult", typeof(AdActionResults));
            }
            catch (ArgumentNullException) {
                //  blah
            }
            catch (InvalidCastException) {
                //  blah blah
            }
            catch (SerializationException) {
                //  yeah, yeah, yeah
            }
            
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context);
            //  'info' is guaranteed to be non-null by the above call to GetObjectData (will throw an exception there if null)
            info.AddValue("AdResult", AdResult);
            info.AddValue("LdsResult", LdsResult);
            
        }
    }
