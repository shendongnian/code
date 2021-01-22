    string xml = @"<graph>
    <node>
       <node>
         <node></node>
       </node>
    </node>
    <node>
       <node>
         <node></node>
       </node>
    </node>
    </graph>";
    [XmlRoot("graph")]
    public class graph
    {
        [XmlElement("node")]
        public Node[] node;
    }
    
    public class Node
    {
        [XmlElement("node")]
        public Node[] children;
    }
    
    XmlSerializer serializer = new XmlSerializer(typeof(graph));
    MemoryStream stream = new MemoryStream();
    StreamWriter writer = new StreamWriter(stream);
    writer.Write(xml.Replace(Environment.NewLine, String.Empty));
    writer.Flush();
    stream.Position = 0;
    
    var graph = serializer.Deserialize(stream) as graph;
