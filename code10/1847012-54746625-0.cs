    using System;
    using System.Xml.Serialization;
    using UnityEngine;
    
    [Serializable]
    public class Block
    {
        [XmlAttribute] public string Name;
        [XmlElement] public Vector3 Position;
    
        // for the serializer a parameter-free default constructor is mandatory
        public Block() { }
    
        public Block(string name, Vector3 position)
        {
            Name = name;
            Position = position;
        }
    }
