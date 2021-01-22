    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    class Pair : IDataErrorInfo
    {
        internal IList<Pair> Parent { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    
        string IDataErrorInfo.Error
        {
            get { return ""; }
        }
    
        string IDataErrorInfo.this[string columnName]
        {
            get
            {   
                if(columnName == "Key" && Parent != null && Parent.Any(
                    x=> x.Key == this.Key && !ReferenceEquals(x,this)))
                {
                    return "duplicate key";
                }
                return "";        
            }
        }
    }
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            BindingList<Pair> pairs = new BindingList<Pair>();
            // todo: fill from StringDictionary
            pairs.AddingNew += (s,a) =>
            {
                a.NewObject = new Pair { Parent = pairs };
            };
            Application.Run(new Form {
                Controls = {new DataGridView {
                    Dock = DockStyle.Fill,
                    DataSource = pairs
                }}
            });
        }
    }
