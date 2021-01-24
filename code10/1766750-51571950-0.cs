    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.Xml;
    public class Orchestras
    {
        public List<Orchestra> orchestras = new List<Orchestra>();
    }
    public class Orchestra
    {
        [XmlElement]
        public List<Instrument> Instruments { get; set; }
        public int i;
        public float f;
        public string s1;
        public string s2;
        public B bc;
    }
    public class B
    {
        public double dd;
    }
    [XmlInclude(typeof(Brass))]
    [XmlInclude(typeof(Percussion))]
    public class Instrument
    {
        public string Name;
    }
    public class Brass : Instrument
    {
        public bool IsValved;
    }
    public class Percussion : Instrument
    {
        public string name;
    }
    public class Run
    {
        const string FILENAME = @"c:\temp\test.xml";
        public static void Main()
        {
            Run test = new Run();
            test.SerializeObject(FILENAME);
            test.DeserializeObject(FILENAME);
        }
        public void SerializeObject(string filename)
        {
            Orchestras orchastras = new Orchestras();
            Orchestra orchestra1 = new Orchestra();
            orchastras.orchestras.Add(orchestra1);
            List<Instrument> instruments = new List<Instrument>() { 
                new Instrument() { Name = "Brass"},
                new Instrument() { Name = "Percussion"}
            };
            orchestra1.Instruments = instruments;
            // Create the XmlSerializer using the XmlAttributeOverrides.
            XmlSerializer s = new XmlSerializer(typeof(Orchestras));
            // Writing the file requires a TextWriter.
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(filename,settings);
            // Create the object that will be serialized.
            Orchestra band = new Orchestra();
            orchastras.orchestras.Add(band);
            // Create an object of the derived type.
            //Brass i = new Brass();
            //i.Name = "Trumpet";
            //i.IsValved = true;
            //Instrument[] myInstruments = { i };
            //band.Instruments = myInstruments;
            List<Instrument> myInstruments = new List<Instrument>();
            myInstruments.Add(new Brass() { Name = "Trumpet", IsValved = true });
            myInstruments.Add(new Percussion() { Name = "Percussion", name = "Mridangam" });
            band.Instruments = myInstruments;
            band.i = 128;
            band.f = 5.678f;
            band.s1 = "Hi!";
            band.s2 = "GOOD!!!";
            B b = new B();
            b.dd = 2.35674848;
            band.bc = b;
            // Serialize the object.
            s.Serialize(writer, orchastras);
            writer.Close();
        }
        public void DeserializeObject(string filename)
        {
            // Create the XmlSerializer using the XmlAttributeOverrides.
            XmlSerializer s =
               new XmlSerializer(typeof(Orchestras));
            FileStream fs = new FileStream(filename, FileMode.Open);
            Orchestras band = (Orchestras)s.Deserialize(fs);
            Console.WriteLine(band.orchestras[1].i);
            Console.WriteLine(band.orchestras[1].f);
            Console.WriteLine(band.orchestras[1].s1);
            Console.WriteLine(band.orchestras[1].s2);
            Console.WriteLine(band.orchestras[1].bc.dd);
            Console.WriteLine("Brass:");
            /* The difference between deserializing the overridden 
            XML document and serializing it is this: To read the derived 
            object values, you must declare an object of the derived type 
            (Brass), and cast the Instrument instance to it. */
            //Brass b;
            //Percussion p;
            Instrument b;
            // Percussion p;
            //b = (Brass)i;
            // int ii = 0;
            foreach (Instrument i in band.orchestras[1].Instruments)
            //foreach(Instrument i in band.List<Instrument>)
            {
                //        int i = 0;
                //   ii++;
                //  if (ii == 1)
                //   {
                b = i;
                Console.WriteLine(
                    b.Name + "\n");
                // }
                /*if (ii == 2)
                {
                    p = (Percussion)i;
                    Console.WriteLine(
                        p.Name + "\n" +
                        p.name);
                }*/
            }
        }
    }
