      [ComVisible(true)]
        public interface IComAddIn
        {
            String GetText();
        }
    
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        public  class AddInUtilities : IComAddIn
        {
            public String GetText()
            {
                return "Now is the winter of dicontent made glorius summer by this son of York";
            }
        }
