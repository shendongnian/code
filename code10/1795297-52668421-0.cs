    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace memorystreams
    {
        public class GetCategoriesReply : BaseReply
        {
            public IEnumerable<Subsystem> Categories { get; set; }
        }
        public class Subsystem
        {
            public IEnumerable<cat1> cat1 { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }
        public class cat1
        {
            public IEnumerable<cat2> cat2 { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }
        public class cat2
        {
            public IEnumerable<cat3> cat3 { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }
        public class cat3
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        public class Result
        {
            public void showlist()
            {
               
                List<cat3> sc3 = new List<cat3>();
                List<cat2> sc2 = new List<cat2>();
                List<cat1> sc1 = new List<cat1>();
                List<Subsystem> sub1 = new List<Subsystem>();
                cat3 cat3_obj = new cat3();
                cat3_obj.id = "3";
                cat3_obj.name = "A";
                cat3 cat3_obj1 = new cat3();
                cat3_obj1.id = "33";
                cat3_obj1.name = "B";
                sc3.Add(cat3_obj);
               // sc3.Add(cat3_obj1);
                cat2 cat2_obj = new cat2();
                cat2_obj.id = "2";
                cat2_obj.name = "A";
                cat2_obj.cat3 = sc3;
                cat2 cat2_obj1 = new cat2();
                cat2_obj1.id = "22";
                cat2_obj1.name = "B";
                cat2_obj1.cat3 = sc3;
                sc2.Add(cat2_obj);
                //sc2.Add(cat2_obj1);
                cat1 cat1_obj = new cat1();
                cat1_obj.id = "1";
                cat1_obj.name = "A";
                cat1_obj.cat2 = sc2;
                cat1 cat1_obj1 = new cat1();
                cat1_obj1.id = "11";
                cat1_obj1.name = "B";
                cat1_obj1.cat2 = sc2;
                sc1.Add(cat1_obj);
               // sc1.Add(cat1_obj1);
                Subsystem ob = new Subsystem();
                ob.id = "S1";
                ob.name = "Sub system";
                ob.cat1 = sc1;
                sub1.Add(ob);
                GetCategoriesReply getCategories = new GetCategoriesReply();
                getCategories.Categories = sub1;
                var catagory3 = (from c1 in getCategories.Categories.Select(x => x.cat1.Select(y => y.cat2.Select(z => z.cat3))) select c1).FirstOrDefault();
                var idob =  catagory3.ToArray()[0];
                var objs = idob.ToArray()[0];
                var strid = objs.ToArray()[0].id;
            }
        }
       public class BaseReply
       {
       }
    }
