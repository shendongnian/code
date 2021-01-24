    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    namespace XmlMvcApplication1.Controllers
    {
        [Serializable]
        public class TestData
        {
            public string id { get; set; }
            public string Name { get; set; }
        }
        public class HomeController : Controller
        {
            public ActionResult SaveItems(string id, string name)
            {
                TestData obj = new TestData();
                obj.id = id;
                obj.Name = name;
                string file = Server.MapPath("~/Data/") + "\\" + id + ".xml";
                if (System.IO.File.Exists(file))
                    System.IO.File.Delete(file);
                FileStream fs = new FileStream(file, FileMode.CreateNew);
                //store into xml file
                XmlSerializer x = new XmlSerializer(typeof(TestData));
                x.Serialize(fs, obj);
                fs.Flush();
                fs.Close();
                return View();
            }
            public ActionResult GetItems(string id)
            {
                string file = Server.MapPath("~/Data/") + "\\" + id + ".xml";
                if (System.IO.File.Exists(file))
                {
                    XDocument xml = XDocument.Load(file);
                    var xmlSerializer = new XmlSerializer(typeof(TestData));
                    var nodes = xml.Descendants("TestData")
                    .Select(rr => xmlSerializer.Deserialize(rr.CreateReader()) as TestData);
                    var deSerializedData = nodes.First();
                    //YOUR CODE HERE
                }
                return View();
            }
        }
    }
