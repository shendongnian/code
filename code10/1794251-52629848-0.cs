    using System.Collections.Generic;
    
    public abstract class Metadata
    {
        public abstract string Name { set; get; }
    }
    
    public class Metadata<T> : Metadata
    {
        public override string Name {set; get;}
    }
    
    public class MetaDataCollection
    {
        public void DoSomeThing()
        {
            List<Metadata> metadataObjects = new List<Metadata>
            {
                new Metadata<int>() { Name = "Name 1"},
                new Metadata<bool>() { Name = "Name 2"},
                new Metadata<double>() { Name = "Name 3"},
            };
    
            foreach(Metadata item in metadataObjects)
            {
                string s = item.Name;
            }
        }
    }
