    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication87
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";   
            static void Main(string[] args)
            {
                Item items = new Item(FILENAME);
            }
        }
        public class Item
        {
            public static List<Item> items = new List<Item>();
            public string VehicleReferenceKey;
            public string DriverReferenceKey;
            public string Latitude;
            public Item() { }
            public Item(string filenam)
            {
                StreamReader reader = new StreamReader(filenam);
                string line = "";
                Item newItem = null;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        string[] rowItems = line.Split(new char[] { ':' });
                        switch (rowItems[0])
                        {
                            case "VehicleReferenceKey" :
                                newItem = new Item();
                                items.Add(newItem);
                                newItem.VehicleReferenceKey = rowItems[1]; 
                                break;
                            case "DriverReferenceKey":
                                newItem.DriverReferenceKey = rowItems[1];
                                break;
                            case "Latitude":
                                newItem.Latitude = rowItems[1];
                                break;
                        }
                    }
                }
            }
        }
     
    }
