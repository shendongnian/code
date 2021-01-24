    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Example {
        public static class Program {
            public static void Main (string[] args) {
                List<RelationDTO> relationDTOList = new List<RelationDTO> {
                    new RelationDTO { PersonId = 1, RelativeId = 2, Relation = "Son" },
                    new RelationDTO { PersonId = 2, RelativeId = 1, Relation = "Father" },
                    new RelationDTO { PersonId = 1, RelativeId = 3, Relation = "Mother" },
                    new RelationDTO { PersonId = 3, RelativeId = 1, Relation = "Son" },
                    new RelationDTO { PersonId = 2, RelativeId = 3, Relation = "Husband" },
                    new RelationDTO { PersonId = 3, RelativeId = 2, Relation = "Wife" },
                };
                // Group relations into list of lists
                var groups = relationDTOList
                    .GroupBy (r => GetOrderedTuple (r.PersonId, r.RelativeId))
                    .Select (grp => grp.ToList ()).ToList ();
    
                // Output original relations and their reverse relations
                foreach (var group in groups) {
                    var relation = group.ElementAt (0);
                    var reverseRelation = group.ElementAt (1);
                    FormattableString relationOutput = $"PersonId={relation.PersonId} RelativeId={relation.RelativeId} Relation={relation.Relation} ReverseRelation={reverseRelation.Relation}";
                    Console.WriteLine (relationOutput);
                }
            }
            private static Tuple<int, int> GetOrderedTuple (int n1, int n2) {
                if (n1 < n2) {
                    return Tuple.Create (n1, n2);
                }
                return Tuple.Create (n2, n1);
            }
        }
    }
