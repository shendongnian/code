        public class Node_Map : ClassMap<Node>
        {
            public Node_Map()
            {
                References(x => x.Parent, "IdCmsNodeParent");
                HasMany(x => x.Childs).AsBag()
                                      .Inverse()
                                      .Cascade.Delete()
                                      .KeyColumn("IdNodeParent");
            }
        }
