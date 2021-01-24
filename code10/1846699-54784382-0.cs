    public class NSPanelExt : NSPanel
    {
        public KeyPressedHandler KeyPressed;
        public delegate void KeyPressedHandler(KeyCodeEventArgs e);
    
        public NSPanelExt(CGRect contentRect, NSWindowStyle aStyle, NSBackingStore bufferingType, bool deferCreation) : base(contentRect, aStyle, bufferingType, deferCreation)
        {
        }
    
        public override bool CanBecomeMainWindow => true;
    
        public override bool CanBecomeKeyWindow => true;
    
        public override bool AcceptsFirstResponder()
        {
            return true;
        }
    
    
        public override void KeyDown(NSEvent theEvent)
        {
            // this function is never called
            KeyPressed?.Invoke(new KeyCodeEventArgs {  Key = GetKeyCode(theEvent.KeyCode) });
    
        }
    
        private KeyCode GetKeyCode(ushort keyCode)
        {
            KeyCode result = KeyCode.Unknown;
            switch (keyCode)
            {
                case 123:
                    result = KeyCode.Left;
                    break;
                case 49:
                    result = KeyCode.Space;
                    break;
                case 124:
                    result = KeyCode.Right;
                    break;
                case 53:
                    result = KeyCode.Esc;
                    break;
            }
    
            return result;
        }
