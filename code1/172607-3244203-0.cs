        public class KeystrokMessageFilter : System.Windows.Forms.IMessageFilter
        {
            public KeystrokMessageFilter() { }
    
            #region Implementation of IMessageFilter
    
            public bool PreFilterMessage(ref Message m)
            {
                if ((m.Msg == 256 /*0x0100*/))
                {
                    switch (((int)m.WParam) | ((int)Control.ModifierKeys))
                    {
                        case (int)(Keys.Control | Keys.Alt | Keys.K):
                            MessageBox.Show("You pressed ctrl + alt + k");
                            break;
                        //This does not work. It seems you can only check single character along with CTRL and ALT.
                        //case (int)(Keys.Control | Keys.Alt | Keys.K | Keys.P):
                        //    MessageBox.Show("You pressed ctrl + alt + k + p");
                        //    break;
                        case (int)(Keys.Control | Keys.C): MessageBox.Show("You pressed ctrl+c");
                            break;
                        case (int)(Keys.Control | Keys.V): MessageBox.Show("You pressed ctrl+v");
                            break;
                        case (int)Keys.Up: MessageBox.Show("You pressed up");
                            break;
                    }
                }
                return false;
            }
    
            #endregion
    
    
        }
