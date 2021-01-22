    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Reflection;
    
    namespace WindowsFormsApplication1 {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e) {
                Assembly asm = Assembly.Load("System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
                Type editor = asm.GetType("System.Windows.Forms.Design.MaskDesignerDialog");
                ConstructorInfo ci = editor.GetConstructor(new Type[] { typeof(MaskedTextBox), typeof(System.ComponentModel.Design.IHelpService) });
                Form dlg = ci.Invoke(new object[] { maskedTextBox1, null }) as Form;
                if (DialogResult.OK == dlg.ShowDialog(this)) {
                    PropertyInfo pi = editor.GetProperty("Mask");
                    maskedTextBox1.Mask = pi.GetValue(dlg, null) as string;
                }
            }
        }
    }
