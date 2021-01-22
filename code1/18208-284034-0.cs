    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Reflection;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                PackageKitItem PKI = new PackageKitItem();
                PKI.ID      = 1;
                PKI.KitName = "2";
                PKI.Name    = "3";
                PKI.Package = 4;
    
                PackageKitItem tempPackKitItem = (PackageKitItem)PKI.ShallowCopy();
    
            }
        }
    
    }
    
    public class Product
    {
        public int ID;
        public string Name;
    
        public Product()
        {
        }
    
        public Product(Product product)
        {
            FieldInfo[] fields = product.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    
            // copy each value over to 'this'
            foreach (FieldInfo fi in fields)
                fi.SetValue(this, fi.GetValue(product));
        }
    
    
    }
    
    public class KitItem:Product
    {
        public string KitName;
        public KitItem ShallowCopy()
        {
            return (KitItem)this.MemberwiseClone();
        }
    
    }
    
    public class PackageKitItem : KitItem
    {
        public int Package;
    
    }
     
