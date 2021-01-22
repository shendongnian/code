    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    [Serializable]
    public class MyEntity
    {
        public string Key { get; set; }
    
        public string[] Items { get; set; }
    
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public bool ShouldSerializeItems()
        {
            return Items != null && Items.Length > 0;
        }
    }
    
    static class Program
    {
        static void Main()
        {
            MyEntity obj = new MyEntity { Key = "abc", Items = new string[0] };
            XmlSerializer ser = new XmlSerializer(typeof(MyEntity));
            ser.Serialize(Console.Out, obj);
        }
    }
