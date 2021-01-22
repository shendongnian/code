    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    public class Account
    {
        // your main property; TODO: your version
        [XmlIgnore]
        public Nullable<DateTime> AccountExpirationDate {get;set;}
    
        // this is a shim property that we use to provide the serialization
        [XmlAttribute("AccountExpirationDate")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public DateTime AccountExpirationDateSerialized
        {
            get {return AccountExpirationDate.Value;}
            set {AccountExpirationDate = value;}
        }
    
        // and here we turn serialization of the value on/off per the value
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeAccountExpirationDateSerialized()
        {
            return AccountExpirationDate.HasValue;
        }
    
        // test it...
        static void Main()
        {
            var ser = new XmlSerializer(typeof(Account));
            var obj1 = new Account { AccountExpirationDate = DateTime.Today };
            ser.Serialize(Console.Out, obj1);
            Console.WriteLine();
            var obj2 = new Account { AccountExpirationDate = null};
            ser.Serialize(Console.Out, obj2);
        }
    }
