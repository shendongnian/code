    public class NeedsEye
    {
    
        Eye _eye = new Eye();
    
        public NeedsEye()
        {
            // now, here, any access to the property must be made through the
            // _eye variable. The Eye class has access to any of the properties
            // and members of the NeedsEye class, but the NeedsEye class has not
            // any access to members of the Eye class.
        }
    
        private class Eye
        {
            private int _orientation;
    
            public int Orientation 
            {
                get { return _orientation; }
    
                if (value < 0)
                {
                   _eyeOrientation = 0;
                }
                else
                {
                   _eyeOrientation = value % 360;
                }     
            }
        }
    }
