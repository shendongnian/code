    using System;
    using System.Windows.Forms;
    
    class MyButton : Button {
        public bool Invisible {
            get { return !Visible; }
            set { Visible = !value; }
        }
    }
