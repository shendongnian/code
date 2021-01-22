    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    namespace XmlLinqTest
    {
        [Serializable]
        [XmlRoot(Namespace = "")]
        public class Orders
        {
            private List<Order> _orders = new List<Order>();
    
            /// <remarks/>
            [XmlElement("Order")]
            public List<Order> OrderList
            {
                get { return _orders; }
            }
        }
    
        /// <remarks/>
        [Serializable]
        public class Order
        {
            /// <remarks/>
            [XmlElement]
            public string ItemNumber { get; set; }
    
            [XmlElement]
            public int QTY { get; set; }
    
            /// <remarks/>
            [XmlElement]
            public string WareHouse { get; set; }
    
            /// <remarks/>
            [XmlAttribute]
            public string OrderNumber { get; set; }
        }
    }
