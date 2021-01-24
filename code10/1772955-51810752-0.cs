    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace Unions
    {
        public partial class Form1 : Form
        {
            [StructLayout(LayoutKind.Explicit)]
            struct uShortArray
            {
                [FieldOffset(0)]
                public ushort Bytes01;
                [FieldOffset(2)]
                public ushort Bytes23;
                [FieldOffset(4)]
                public ushort Bytes45;
                [FieldOffset(6)]
                public ushort Bytes67;
    
                [FieldOffset(0)]
                public long long1;
            }
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, System.EventArgs e)
            {
                uShortArray ua;
                ua.long1 = 0;
                ua.Bytes01 = 999;
                ua.Bytes23 = 164;
                ua.Bytes45 = 581;
                ua.Bytes67 = 43;
    
                MessageBox.Show($"[Bytes 0 - 1 : {ua.Bytes01}] ... [Byte 2 - 3 : {ua.Bytes23}] ... [Bytes 4 - 5 : {ua.Bytes45}] ... [Bytes 6 - 7 : {ua.Bytes67}] ... [long1 : {ua.long1}]");
            }
        }
    }
