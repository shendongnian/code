    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;
    using System.Windows.Forms;
    
    namespace TestApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            SampleLib.SampleType test = new SampleLib.SampleType();
    
            private void button1_Click(object sender, EventArgs e)
            {
                // Dynamically build and call the method
                label1.Text = test.MyText;
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                StringBuilder DynamicCode = new StringBuilder();
                DynamicCode.Append("namespace TestDynamic");
                DynamicCode.Append("{");
                DynamicCode.Append("public class DynamicCode");
                DynamicCode.Append("{");
                DynamicCode.Append("public static void EditText(SampleLib.SampleType t)");
                DynamicCode.Append("{");
                DynamicCode.Append("t.MyText = \"Goodbye!\";");
                DynamicCode.Append("}");
                DynamicCode.Append("}");
                DynamicCode.Append("}");
    
                string CodeString = DynamicCode.ToString();
    
                System.IO.FileInfo fi = new System.IO.FileInfo(Application.ExecutablePath);
                CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
                CompilerParameters CompileParams = new CompilerParameters(new string[] { fi.DirectoryName + "\\SampleLib.dll" },
                    fi.DirectoryName + "\\Dynamic.dll");
                CompileParams.MainClass = "DynamicCode";
                CompileParams.GenerateExecutable = false;
                //CompileParams.GenerateInMemory = true;
                CompilerResults r = provider.CompileAssemblyFromSource(CompileParams, new string[] {CodeString});
                foreach (CompilerError er in r.Errors)
                {
                    Console.WriteLine(er.ErrorText);
                }
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                // Dynamically call assembly
                System.IO.FileInfo fi = new System.IO.FileInfo(Application.ExecutablePath);
                Assembly dynAsm = Assembly.LoadFile(fi.DirectoryName + "\\Dynamic.dll");
                if (dynAsm != null)
                {
                    object o = dynAsm.CreateInstance("TestDynamic.DynamicCode", true);
                    Type t = dynAsm.GetType("TestDynamic.DynamicCode");
                    t.GetMethod("EditText").Invoke(o, new object[]{test});
                }
            }
        }
    }
