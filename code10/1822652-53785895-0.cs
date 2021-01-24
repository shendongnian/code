    using System;
    namespace HelloWorld
    {
        internal class Color
        {
    
            public Color(byte red, byte green, byte blue, byte alpha)
            {
                this.Red= red;
                this.Green = green;
                this.Blue = blue;
                this.Alpha= alpha;
            }
    
            public Color(byte red, byte green, byte blue)
            {
                this.Red= red;
                this.Green = green;
                this.Blue = blue;
                this.Alpha = 255;
            }
    
            public byte Red { get; set; }
            public byte Green { get; set; }
            public byte Blue { get; set; }
            public byte Alpha { get; set; }
    
    
    
            public float GreyScale
            {
                get
                {
                    return (this.Red + this.Green + this.Blue) / 3.0F;
                }
            }
        }
    }
