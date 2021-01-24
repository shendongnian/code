    // NEEDED IMPORTS
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    static void Main(string[] args)
    {
      // build a list of lists from 0 to 99 divided on 
      // 10 inner list each with 10 elements
      List<List<string>> list = new List<List<string>>();
      for(int i=0; i<10; i++)
      {
        list.Add(new List<string>());
        for (int j = i * 10; j < i * 10 + 10; j++)
          list[i].Add(j.ToString());
      }
      // serialize to xml 
      XmlSerializer ser = new XmlSerializer(list.GetType());
      TextWriter writer = new StreamWriter("serialized.xml");
      ser.Serialize(writer, list);
    }
