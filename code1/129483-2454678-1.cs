    namespace WindowsFormsApplication1
    {
        using System;
        using System.ComponentModel;
        using System.Drawing.Design;
        using System.Globalization;
        using System.Windows.Forms;
        using System.Windows.Forms.Design;
        class MyEditor : FileNameEditor
        {
            public override bool GetPaintValueSupported(ITypeDescriptorContext context)
            {
                return false;
            }
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {                       
                object e = base.EditValue(context, provider, value);
                var myFile = value as MyFile;
                if (myFile != null && e is string)
                {
                    myFile.FileName = (string)e;
                    return myFile;
                }
                return e;
            }
        }
        class MyFileTypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;
                return base.CanConvertFrom(context, sourceType);
            }
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(string))
                    return true;
                return base.CanConvertTo(context, destinationType);
            }
            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                if (value is string) 
                    return new MyFile { FileName = (string) value };
                return base.ConvertFrom(context, culture, value);
            }
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                var myFile = value as MyFile;
                if (myFile != null && destinationType == typeof(string))
                    return myFile.FileName;
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
        [TypeConverter(typeof(MyFileTypeConverter))]
        [Editor(typeof(MyEditor), typeof(UITypeEditor))]
        class MyFile
        {
            public string FileName { get; set; }
        }
        
        class MyFileContainer
        {
            public MyFileContainer()
            {
                File1 = new MyFile { FileName = "myFile1.txt" };
                File2 = new MyFile { FileName = "myFile2.txt" };
            }
            
            public MyFile File1 { get; set; }
            public MyFile File2 { get; set; }
        }
        public partial class Form1 : Form
        {
            
            public Form1()
            {
                InitializeComponent();
                propertyGrid1.SelectedObject = new MyFileContainer();
            }
        }
    }
