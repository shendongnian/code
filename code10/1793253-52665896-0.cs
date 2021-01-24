    using DeptDataAccess;
    using System.Xml.Serialization;
    namespace TempNamespace.DepartmentPClass
    {
        [XmlType("DocumentElement")]
        public class Items : List<Item>
        {
            public Items()
            {
                using (DeptDBEntities entities = new DeptDBEntities())
                {
                    foreach (Department entity in entities.Departments)
                    {
                        Item item = new Item(entity);
                        this.Add(item);
                    }
                }
            }
        }
        public class Item
        {
            public int ID { get; set; }
            public string Text_1 { get; set; }
            public string Text_2 { get; set; }
            public string Company { get; set; }
            public Item()
            {
                this.ID = 0;
                this.Text_1 = string.Empty;
                this.Text_2 = string.Empty;
                this.Company = string.Empty;
            }
            public Item(int id, string text_1, string text_2, string company)
            {
                this.ID = id;
                this.Text_1 = text_1;
                this.Text_2 = text_2;
                this.Company = company;
            }
            public Item(Department entity)
            {
                this.ID = entity.ID;
                this.Text_1 = entity.Text_1;
                this.Text_2 = entity.Text_2;
                this.Company = entity.Company;
            }
        }
    }
