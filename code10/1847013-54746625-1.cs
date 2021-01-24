    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using UnityEngine;
    
    [XmlRoot("BlocksData")]
    [Serializable]
    public class BlocksData
    {
        [XmlArray]
        [XmlArrayItem]
        public List<Block> Blocks = new List<Block>();
    
        public void Save(string filePath)
        {
            var serializer = new XmlSerializer(typeof(BlocksData));
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, this);
            }
        }
    
        public static BlocksData Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Debug.LogWarning("File not found: " + filePath);
            }
    
            var serializer = new XmlSerializer(typeof(BlocksData));
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return serializer.Deserialize(stream) as BlocksData;
            }
        }
    }
