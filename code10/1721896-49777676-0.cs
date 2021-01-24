    public class ItemMap: ClassMap<Item>
        {
            public ItemMap()
            {
                Id(x => x.serialNumber);
                References(x => x.Project, "idProject");//you need to change your property to actual entity, not just Id
                Map(x => x.type);
                Table("NameOfTable");
            }
        }
