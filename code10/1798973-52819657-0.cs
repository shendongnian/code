    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
             static void Main(string[] args)
            {
                var typeBuildingPart = new List<IfcBuildingPart> {
                    new IfcBuildingPart{
                        BIMId = "iojeofhwofh308ry308hi32r08yrh",
                        Reference = "234",
                        Assets = new List<IfcAsset> {
                            new IfcAsset{
                                ObjectID = 6111838616,
                            }
                        }
                    },
                                    new IfcBuildingPart{
                        Reference = "235",
                        Assets = new List<IfcAsset> {
                            new IfcAsset{
                                ObjectID = 6111838616,
                            }
                        }
                    },
                       new IfcBuildingPart{
                        Reference = "235",
                        Assets = new List<IfcAsset> {
                            new IfcAsset{
                                ObjectID = 6111838616,
                            }
                        }
                    }
                 };
                var dictRefToObj = typeBuildingPart.GroupBy(x => x.Reference, y => y.Assets.Select(z => z.ObjectID))
                    .ToDictionary(x => x.Key, y => y.SelectMany(z => z).GroupBy(a => a).Select(a => new { obj = a.Key, count = a.Count()}).ToList());
                
                 
                 var dictObjToRef = dictRefToObj.Select(x => x.Value.Select(y => new { reference = x.Key, obj = y.obj, count = y.count })).SelectMany(z => z)
                    .GroupBy(x => x.obj, y => new { reference = y.reference, count = y.count})
                    .ToDictionary(x => x.Key, y => new { total = y.Select(z => z.count).Sum(), references = y.Select(z => new { reference = z.reference, count = z.count}).ToList()});
                    
     
            }
        }
        public class IfcBuildingPart
        {
            public string BIMId { get; set; }
            public string Reference { get; set; }
            public List<IfcAsset> Assets { get; set; }
        }
        public class IfcAsset
        {
            public long ObjectID { get; set; }
        }
    }
