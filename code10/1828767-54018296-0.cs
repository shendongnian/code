    public static void Main()
    {
        List<RelationDTO> relationDTOList = new List<RelationDTO>
        {
            new RelationDTO { PersonId = 1, RelativeId = 2, Relation = "Son" },
            new RelationDTO { PersonId = 2, RelativeId = 1, Relation = "Father" },
            new RelationDTO { PersonId = 1, RelativeId = 3, Relation = "Mother" },
            new RelationDTO { PersonId = 3, RelativeId = 1, Relation = "Son" },
            new RelationDTO { PersonId = 2, RelativeId = 3, Relation = "Husband" },
            new RelationDTO { PersonId = 3, RelativeId = 2, Relation = "Wife" },
        };
        var grp = relationDTOList.Join(relationDTOList, 
                dto => dto.PersonId + "-" + dto.RelativeId, 
                dto => dto.RelativeId + "-" + dto.PersonId, 
        (dto1, dto2) => new Relations 
                { 
                    PersonId = dto1.PersonId, 
                    RelationId = dto1.RelativeId, 
                    Relation = dto1.Relation, 
                    ReverseRelation = dto2.Relation 
                    }).Distinct(new MyEqualityComparer());
        foreach (var g in grp)
            Console.WriteLine("{0},{1},{2},{3}", g.PersonId, g.RelationId, g.Relation, g.ReverseRelation);
    }
    public class MyEqualityComparer : IEqualityComparer<Relations>
    {
        public bool Equals(Relations x, Relations y)
        {
            return x.PersonId + "-" + x.RelationId == y.PersonId + "-" + y.RelationId || 
            x.PersonId + "-" + x.RelationId == y.RelationId + "-" + y.PersonId;
        }
        public int GetHashCode(Relations obj)
        {
            return 0;
        }
    }
