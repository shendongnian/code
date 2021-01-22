    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1 {
       public class MyObject {
          public MyObject(string someValue) {
             SomeValue = someValue;
          }
    
          protected string SomeValue { get; set; }
          public override string ToString() {
             return SomeValue;
          }
       }
    
    
       public partial class Form1 : Form {
          public Form1() {
             InitializeComponent();
    
             var list = new List<MyObject> { 
                new MyObject("Item one"), new MyObject("Item two")
             };
             listBox1.DataSource = list;
          }
          private void listBox1_DoubleClick(object sender, EventArgs e) {
             Debug.WriteLine("DoubleClick event fired on ListBox");
          }
       }
    }
