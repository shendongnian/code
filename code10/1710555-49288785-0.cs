    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    //using Projektverwaltung.Interfaces;
    
    namespace Projektverwaltung.Klassen
    {
        [Serializable()]
        public class CustomerManager//: IXmlSerializable
        {
            public CustomerManager()
            {
    
            }
            [XmlIgnore]
            EventHandler m_EditHandle = new EventHandler(DefaultHandle);
            [XmlIgnore] Dictionary<int, Customer> m_CostumerList = new Dictionary<int, Customer>();
    
            [XmlIgnore] public Dictionary<int, Customer> CostumerList { get { return m_CostumerList; } set { m_CostumerList = value; } }
    
          
           [XmlArray(ElementName = "CostumerList",IsNullable =true)]
            List<Customer> listtemp = new List<Customer>();
            public List<Customer> list
            {
                get
                {
                  
                    try
                    {
                       
                        foreach (var item in CostumerList.Values)
                        {
                            if (!listtemp.Exists(match=>match.ID==item.ID))
                            {
                                listtemp.Add(item);
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {
    
                        Program.Log(ex);
                    }
    
    
                    return listtemp;
                }
                set
                {
    
                }
            }               
            
            
            private static void DefaultHandle(object sender, EventArgs e) { }
    
           
    
    
            [XmlIgnore] public EventHandler EditCostumerEvent { get { return m_EditHandle; } set { m_EditHandle = value; } }
    
    
            public int IncrementID()
            {
                int defaultindex = 0;
                try
                {
                  
                    foreach (var item in CostumerList.Keys)
                    {
                        defaultindex = defaultindex < item ? item : defaultindex;
                    }
                   
                }
                catch (Exception ex)
                {
                    Program.Log(ex);
                }
                return defaultindex + 1;
            }
    
    
        }
    }
