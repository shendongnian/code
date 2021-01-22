    using System;
    using System.Reflection;
    
    namespace PropertyViaString
    {
        public class Shipment
        {
            public string Sender { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Shipment shipment = new Shipment();
                SetValueExample(shipment, "Sender", "Popeye");
                Console.WriteLine("Sender is {0}", shipment.Sender);
                Console.ReadKey();
            }
    
            static void  SetValueExample(Shipment shipment, string propName, string valueToUse)
            {
                Type type = shipment.GetType();
                PropertyInfo senderProperty = type.GetProperty(propName);
                senderProperty.SetValue(shipment, valueToUse, null);
            }
    
        }
    }
