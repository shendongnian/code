    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("JamHeadArt.ClassEX")]
    [Guid("XYZ")]
    public partial class ClassEX : IClassEX
    {
        public ClassEX()
        {
            // Empty constructor here, some of mine have processes, all work well
        }  
        public ClassEX(string foo)
        {
            // additional constructor, can be used for unit testing etc.
        }  
    
        // Methods/ Properties as outlined by the interface below
    }
