    public struct Color32
    {
        const uint BlueMask  = 0xFF000000;       
        const uint GreenMask = 0x00FF0000;
        const uint RedMask   = 0x0000FF00;
        const uint AlphaMask = 0x000000FF;
        const int BlueShift  = 24;       
        const int GreenShift = 16;
        const int RedShift   = 8;
        const int AlphaShift = 0;
        private byte GetComponent(uint mask, int shift)
        {
            var b = (this.ARGB & mask);
            return (byte) (b >> shift);            
        } 
        private void SetComponent(int shift, byte value)
        {
            var b = ((uint)value) << shift
            this.ARGB |= b;
        } 
     
        public byte Blue 
        {
            get { return GetComponent(BlueMask, BlueShift); }
            set { SetComponent(BlueShift, value); }
        }
 
        public byte Green
        {
            get { return GetComponent(GreenMask, GreenShift); }
            set { SetComponent(GreenShift, value); }
        }
        public byte Red
        {
            get { return GetComponent(RedMask, RedShift); }
            set { SetComponent(RedShift, value); }
        }
        public byte Alpha
        {
            get { return GetComponent(AlphaMask, AlphaShift); }
            set { SetComponent(AlphaShift, value); }
        }
        /// <summary>
        /// Permits the color32 to be treated as an UInt32
        /// </summary>
        public uint ARGB;
        /// <summary>
        /// Return the color for this Color32 object
        /// </summary>
        public Color Color
        {
            get { return Color.FromArgb(Alpha, Red, Green, Blue); }
        }
    }
