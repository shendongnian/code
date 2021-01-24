using System.Xml;
Create a new XmlDocument object:
XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
If you are reading xml from a file, use xmlDoc.Load(string filename):
xmlDoc.Load("yourXMLFile.xml");
If you are reading xml from a string, use xmlDoc.LoadXml(string xml):
xmlDoc.LoadXml(xmlStringVariable);
From there, you can parse through your XML by the tag names and child nodes. Here is a simple example, but hopefully it will give you a start: 
XmlNodeList childList = xmlDoc.GetElementsByTagName("CHILD");
var _child = childList[0];
for (int i = 0; i < childList.Count; i++)
{
    // Do work 
    // Loop through child nodes
    for(int c = 0; c < childList[i].ChildNodes.Count; c++)
    {
        // Do something with child nodes
        var _childNode = childList[i].ChildNodes[c].InnerXml;
    }
}
