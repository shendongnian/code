    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    #if SILVERLIGHT
    using SystemColor = System.Windows.Media.Color;
    #else
    using SystemColor = System.Drawing.Color;
    #endif
    
    namespace SpreadsheetGear.Drawing
    {
        /// <summary>
        /// Represents a Color in the SpreadsheetGear API and provides implicit conversion operators to and from System.Drawing.Color and / or System.Windows.Media.Color.
        /// </summary>
        public struct Color
        {
            public override string ToString()
            {
                //return string.Format("Color({0}, {1}, {2})", R, G, B);
                return _color.ToString();
            }
    
            public override bool Equals(object obj)
            {
                return (obj is Color && (this == (Color)obj))
                    || (obj is SystemColor && (_color == (SystemColor)obj));
            }
            ...
