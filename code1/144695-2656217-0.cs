    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;
    using System.Globalization;
    
    namespace WindowsControlLibrary1
    {
        public class MyTypeConverter : TypeConverter
        {
            // Overrides the CanConvertFrom method of TypeConverter.
            // The ITypeDescriptorContext interface provides the context for the
            // conversion. Typically, this interface is used at design time to 
            // provide information about the design-time container.
            public override bool CanConvertFrom(ITypeDescriptorContext context,
               Type sourceType)
            {
    
                if (sourceType == typeof(string))
                {
                    return true;
                }
                return base.CanConvertFrom(context, sourceType);
            }
            // Overrides the ConvertFrom method of TypeConverter.
            public override object ConvertFrom(ITypeDescriptorContext context,
               CultureInfo culture, object value)
            {
                if (value is string)
                {
                    string[] v = ((string)value).Split(new char[] { ',' });
                    return new MyPoint(int.Parse(v[0]), int.Parse(v[1]));
                }
                return base.ConvertFrom(context, culture, value);
            }
            // Overrides the ConvertTo method of TypeConverter.
            public override object ConvertTo(ITypeDescriptorContext context,
               CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    return ((MyPoint)value).X + "," + ((MyPoint)value).Y;
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    
        [SerializableAttribute]
        [TypeConverterAttribute(typeof(MyTypeConverter))]
        public struct MyPoint
        {
            private int x;
            private int y;
    
            public MyPoint(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
    
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
    
        }
    
        public partial class UserControl1 : UserControl
        {
            private List<System.Drawing.Point> points;
            private List<System.Drawing.PointF> pointfs;
            private List<MyPoint> mypoints;
    
    
            public List<System.Drawing.Point> PointList
            {
                get{ return points;}
                set{ points = value;}
            }
    
            public List<System.Drawing.PointF> PointFList
            {
                get {return pointfs;}
                set{pointfs = value;}
            }
    
            public List<MyPoint> MyPointList
            {
                get { return mypoints; }
                set { mypoints = value; }
            }
    
            public UserControl1()
            {
                InitializeComponent();
            }
        }
    }
