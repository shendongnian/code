    public class MyAttribute : Attribute
    {
        public MyAttribute(UnmanagedType foo)
        {
        }
        public int Bar { get; set; }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct Test
    {
        [CLSCompliant(false)]
        [MyAttribute(UnmanagedType.ByValArray, Bar = 4)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] ArrayShorts;
    }
    class Program
    {
        static void Main(string[] args)
        {
            FieldInfo field_info = typeof(Test).GetField("ArrayShorts");
            object[] custom_attributes = field_info.GetCustomAttributes(typeof(MarshalAsAttribute), false);
            Debug.WriteLine("Attributes: " + custom_attributes.Length.ToString());
            custom_attributes = field_info.GetCustomAttributes(typeof(MyAttribute), false);
            Debug.WriteLine("Attributes: " + custom_attributes.Length.ToString());
            custom_attributes = field_info.GetCustomAttributes(typeof(CLSCompliantAttribute), false);
            Debug.WriteLine("Attributes: " + custom_attributes.Length.ToString());
        }
    }
