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
                uShortArray ua = default(uShortArray);
                ua.Bytes01 = 999;
                ua.Bytes23 = 164;
                ua.Bytes45 = 581;
                ua.Bytes67 = 43;
    
                MessageBox.Show($"ua = [Bytes 0 - 1 : {ua.Bytes01}] ... [Byte 2 - 3 : {ua.Bytes23}] ... [Bytes 4 - 5 : {ua.Bytes45}] ... [Bytes 6 - 7 : {ua.Bytes67}] ... [long1 : {ua.long1}]");
    
                uShortArray ua2 = default(uShortArray);
    
                Combine(out ua2, 543, 657, 23, 999);
    
                MessageBox.Show($"ua2 = [Bytes 0 - 1 : {ua2.Bytes01}] ... [Byte 2 - 3 : {ua2.Bytes23}] ... [Bytes 4 - 5 : {ua2.Bytes45}] ... [Bytes 6 - 7 : {ua2.Bytes67}] ... [long1 : {ua2.long1}]");
    
                uShortArray ua3 = default(uShortArray);
                ua3.long1 = ua.long1;  //As you can see, you don't need an extract.  You just assign the "extract" value to long1.
    
                MessageBox.Show($"ua3 = [Bytes 0 - 1 : {ua3.Bytes01}] ... [Byte 2 - 3 : {ua3.Bytes23}] ... [Bytes 4 - 5 : {ua3.Bytes45}] ... [Bytes 6 - 7 : {ua3.Bytes67}] ... [long1 : {ua3.long1}]");
            }
    
            private void Combine(out uShortArray inUA, ushort in1, ushort in2, ushort in3, ushort in4)
            {
                inUA = default(uShortArray);
    
                inUA.Bytes01 = in1;
                inUA.Bytes23 = in2;
                inUA.Bytes45 = in3;
                inUA.Bytes67 = in4;
            }
        }
    }
