    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    // experimental code : tested to a limited extent
    // use only for educational purposes
    
    namespace complexTree
    {
        // foundation abstract class template
        public abstract class idioNode
        {
            // a collection of "itself" !
            public List<idioNode> Nodes { private set; get; }
    
            public idioNode Parent { get; set; }
    
            public idioNode()
            {
                Nodes = new List<idioNode>();
            }
    
            public void Add(idioNode theNode)
            {
                Nodes.Add(theNode);
                theNode.Parent = this;
            }
        }
    
        // strongly typed Node of type String
        public class idioString : idioNode
        {
            public string Value { get; set; }
    
            public idioString(string strValue)
            {
                Value = strValue;
            }
        }
    
        // strongly typed Node of type Int
        public class idioInt : idioNode
        {
            public int Value { get; set; }
    
            public idioInt(int intValue)
            {
                Value = intValue;
            }
        }
    
        // strongly type Node of a complex type
        // note : this is just a "made-up" test case
        // designed to "stress" this experiment
        // it certainly doesn't model any "real world"
        // use case
        public class idioComplex : idioNode
        {
            public Dictionary<idioString, idioInt> Value { get; set; }
    
            public idioComplex(idioInt theInt, idioString theString)
            {
                Value = new Dictionary<idioString, idioInt>();
                Value.Add(theString, theInt);
            }
    
            public void Add(idioInt theInt, idioString theString)
            {
                Value.Add(theString, theInt);
                theInt.Parent = this;
                theString.Parent = this;
            }
        }
    
        // special case the Tree's root nodes
        // no particular reason for doing this
        public class idioTreeRootNodes : List<idioNode>
        {
            public new void Add(idioNode theNode)
            {
                base.Add(theNode);
                theNode.Parent = null;
            }
        }
    
        // the Tree object
        public class idioTree
        {
            public idioTreeRootNodes Nodes { get; set; }
    
            public idioTree()
            {
                Nodes = new idioTreeRootNodes();
            }
        }
    }
