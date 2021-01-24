using System;
using System.Collections.Generic;
using YamlDotNet.RepresentationModel;
namespace YamlTransform
{
    public static class Extensions
    {
        public static YamlNode XPath(this YamlDocument doc, string path)
        {
            if (!(doc.RootNode is YamlMappingNode mappingNode)) // Cannot search non mapping nodes
            {
                return null;
            }
            var sections = new Queue<string>(path.Split('/', StringSplitOptions.RemoveEmptyEntries));
            while (sections.Count > 1)
            {
                string nextSection = sections.Dequeue();
                var key = new YamlScalarNode(nextSection);
                if (mappingNode == null || !mappingNode.Children.ContainsKey(key))
                {
                    return null; // Path does not exist
                }
                mappingNode = mappingNode[key] as YamlMappingNode;
            }
            return mappingNode?[new YamlScalarNode(sections.Dequeue())];
        }
    }
}
