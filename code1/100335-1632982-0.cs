    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    
        namespace MyControls
        {
            public class Textbox : System.Web.UI.WebControls.TextBox
            {
                public override string ClientID
                {
                    get
                    {
                        return ID;
                    }
        
                }
        
                public override string UniqueID
                {
                    get
                    {
                        return ID;
                    }
                }
        
            }
        
            public class Button : System.Web.UI.WebControls.Button
            {
        
                public override string ClientID
                {
                    get
                    {
                        return ID;
                    }
        
                }
        
                public override string UniqueID
                {
                    get
                    {
                        return ID;
                    }
                }
            }
        }
