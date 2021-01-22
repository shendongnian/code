    public class MyXmlProcessorFactory
    {
        public static IMyXmlProcessor GetMyXmlProcessor(XmlDocument document)
        {
             XmlNode rootNode = document.DocumentElement;
             if (rootNode.SelectSingleNode("NodeA") != null)
             {
                  return new NodeAMyXmlProcessor();
             }
             else if (rootNode.SelectSingleNode("NodeB") != null)
             {
                  return new NodeBMyXmlProcessor();
             }
             else if (rootNode.SelectSingleNode("NodeC") != null)
             {
                  return new NodeCMyXmlProcessor();
             }
             else
             {
                  return new DefaultMyXmlProcessor();
             }
        }
    }
