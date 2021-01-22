    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Win32;
    namespace RegistryTest1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                WriteKey();
            }
            private void button2_Click(object sender, EventArgs e)
            {
                ReadKey();
            }
            private string keyPath = "SOFTWARE\\My Registry Key";
            private string keyName = "TestKeyName";
            private string keyValue = "TestValue";
            private void WriteKey()
            {
                Registry.LocalMachine.CreateSubKey(keyPath);
                RegistryKey myKey = Registry.LocalMachine.OpenSubKey(keyPath, true);
                myKey.SetValue(keyName, keyValue, RegistryValueKind.String);
            }
            private void ReadKey()
            {
                RegistryKey myKey = Registry.LocalMachine.OpenSubKey(keyPath, checkBox1.Checked);
                string myValue = (string)myKey.GetValue(keyName);
                textBox1.Text = myValue;
            }
            private void button3_Click(object sender, EventArgs e)
            {
                textBox1.Text = "";
            }
        }
    }
