    using System;
    using System.ComponentModel;
    public class DisplayFormatAttribute : Attribute
    {
        public DisplayFormatAttribute(string format)
        {
            Format = format;
        }
        public string Format { get; set; }
    }
