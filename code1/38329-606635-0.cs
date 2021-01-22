    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    namespace Test
    {
        [Serializable]
        public class TestObject
        {
            private String name;
            private String note;
            #region Getters/setters
    
            public String Name
            {
                get { return name; }
                set { name = value; }
            }
    
            public String Note
            {
                get { return note; }
                set { note = value; }
            }
            #endregion
    	}
    }
