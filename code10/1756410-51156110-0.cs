    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;
    
    namespace Rextester
    {
        public class House
        {
            public int Id {set; get;}
            public string Name {set; get;}
            public float Area{set; get;}
            public string ShortName{set; get;}
            public string FarmName{set; get;}
    
        }
        public class MyJason
        {
            public int Code { set; get; }
            public string Message { set; get; }
            public MyData Data { set; get; }
    
        }
    
        public class MyData
        {
            public MyData()
            {
                Houses = new List<House>();
            }
            public List<House> Houses { set; get; }
        }
        
        public class Program
        {
            public static void Main(string[] args)
            {
                string jason= "{'Code':0,'Message':'OK','Data':{'Houses':[{'Id':1,'Name':'House 1','Area':'22.00','ShortName':'H1','FarmName':'Farm 1'},{'Id':2,'Name':'Farmi1 - House 1','Area':'1000.00','ShortName':'H1','FarmName':'Farm 1'}]}}";
                MyJason myJson = JsonConvert.DeserializeObject<MyJason>(jason);
                List<House> Houses = new List<House>();
                Houses = myJson.Data.Houses;
                Console.WriteLine(Houses.FirstOrDefault().Name);
                
            }
        }
    }
