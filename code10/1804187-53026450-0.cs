    using System.IO;
    using System.Linq;
    using Aspose.Words;
    using Aspose.Words.Fields;
    
    namespace ConsoleApplication1
    {
      public class Program
      {
        public static void Main()
        {
          Stream file = new FileStream("SO.docx", FileMode.Open);
          var doc = new Document(file);
    
          var nodes = doc.GetChildNodes(NodeType.Any, true);
    
          foreach (var node in nodes)
          {
            if (node.NodeType != NodeType.Paragraph)
              continue;
            if (!(node is Paragraph fields))
              continue;
    
            if (fields.ChildNodes.Any(x => x.NodeType == NodeType.FieldStart))
            {
              var childNodes = fields.ChildNodes;
              var isParagraphContainsMergedField = childNodes.Any(x => (x as FieldChar)?.FieldType == FieldType.FieldMergeField);
              if (isParagraphContainsMergedField)
                continue;
            }
    
            node.Range.UpdateFields();
          }
    
          var outStream = new MemoryStream();
          doc.Save(outStream, SaveFormat.Pdf);
          File.WriteAllBytes("test.pdf", outStream.ToArray());
        }
      }
    }
