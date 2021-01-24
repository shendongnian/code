            // Extracted using Reflection
            // This will not compile as Control.EventMouseDown is a private member
            System.Windows.Forms.MouseEventHandler mouseEventHandler = (System.Windows.Forms.MouseEventHandler)this.Events[System.Windows.Forms.Control.EventMouseDown];
            if (mouseEventHandler == null)
                return;
            mouseEventHandler(sender, e);
