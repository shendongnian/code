    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using ProtoBuf;
    [XmlType]      // not actually serialized as xml; simply it needs
    class MyData   // a way of identifying the members, and it supports
    {              // the Order property via XmlType/XmlElement
        [XmlElement(Order = 1)] public int Id { get; set; }
        [XmlElement(Order = 2)] public string Name { get; set; }
    }
    static class Program
    {
        static IEnumerable<MyData> GetItems()
        {
            Random rand = new Random();
            int count = 0;
            while (true) // an infinite sequence of data; mwahahaahah
            {
                yield return new MyData
                {
                    Id = rand.Next(0, 5000),
                    Name = "Item " + count++
                };
            }
        }
        static void Main()
        {
            int space = 2048, count = 0;
            long checksum = 0;
            using(Stream dest = File.Create("out.bin"))
            using(MemoryStream buffer = new MemoryStream())
            {
                foreach (MyData obj in GetItems())
                {
                    buffer.SetLength(0); // reset to empty, but retaining buffer to reduce allocs
                    Serializer.SerializeWithLengthPrefix(buffer, obj, PrefixStyle.Base128, 1);
                    int len = (int)buffer.Length;
                    if(buffer.Length <= space) {
                        // add our item
                        dest.Write(buffer.GetBuffer(), 0, len);
                        space -= len;
                        checksum += obj.Id;
                        count++;
                    } else {
                        break; // or new file, whatever
                    }
                }
            }
            Console.WriteLine("Wrote " + count + " objects; chk = " + checksum);
    
            using (Stream source = File.OpenRead("out.bin"))
            {
                count = 0;
                checksum = 0;
                foreach (MyData item in
                    Serializer.DeserializeItems<MyData>(source, PrefixStyle.Base128, 1))
                {
                    count++;
                    checksum += item.Id;
                }
            }
    
            Console.WriteLine("Read " + count + " objects; chk = " + checksum);
        }
    }
