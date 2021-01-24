    public partial class BarcodeReader : Form
        {
    
            char cforKeyDown = '\0';
            int _lastKeystroke = DateTime.Now.Millisecond;
            List<char> _barcode = new List<char>(1);
            bool UseKeyboard = false;
            public BarcodeReader()
            {
                InitializeComponent();
            }
            private void BarcodeReader_Load(object sender, EventArgs e)
            {
                this.KeyDown += new KeyEventHandler(BarcodeReader_KeyDown);
                this.KeyUp += new KeyEventHandler(BarcodeReader_KeyUp);
            }
            private void BarcodeReader_KeyUp(object sender, KeyEventArgs e)
            {
                // if keyboard input is allowed to read
                if (UseKeyboard && e.KeyData != Keys.Enter)
                {
                    MessageBox.Show(e.KeyData.ToString());
                }
    
                /* check if keydown and keyup is not different
                 * and keydown event is not fired again before the keyup event fired for the same key
                 * and keydown is not null
                 * Barcode never fired keydown event more than 1 time before the same key fired keyup event
                 * Barcode generally finishes all events (like keydown > keypress > keyup) of single key at a time, if two different keys are pressed then it is with keyboard
                 */
                if (cforKeyDown != (char)e.KeyCode || cforKeyDown == '\0')
                {
                    cforKeyDown = '\0';
                    _barcode.Clear();
                    return;
                }
    
                // getting the time difference between 2 keys
                int elapsed = (DateTime.Now.Millisecond - _lastKeystroke);
    
                /*
                 * Barcode scanner usually takes less than 17 milliseconds as per my Barcode reader to read , increase this if neccessary of your barcode scanner is slower
                 * also assuming human can not type faster than 17 milliseconds
                 */
                if (elapsed > 17)
                    _barcode.Clear();
    
                // Do not push in array if Enter/Return is pressed, since it is not any Character that need to be read
                if (e.KeyCode != Keys.Return)
                {
                    _barcode.Add((char)e.KeyData);
                }
    
                // Barcode scanner hits Enter/Return after reading barcode
                if (e.KeyCode == Keys.Return && _barcode.Count > 0)
                {
                    string BarCodeData = new String(_barcode.ToArray());
                    if (!UseKeyboard)
                        MessageBox.Show(String.Format("{0}", BarCodeData));
                    _barcode.Clear();
                }
    
                // update the last key press strock time
                _lastKeystroke = DateTime.Now.Millisecond;
            }
    
            private void BarcodeReader_KeyDown(object sender, KeyEventArgs e)
            {
                //Debug.WriteLine("BarcodeReader_KeyDown : " + (char)e.KeyCode);
                cforKeyDown = (char)e.KeyCode;
            }
        }
