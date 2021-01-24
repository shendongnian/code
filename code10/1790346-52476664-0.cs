    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
           static void Main(string[] args)
            {
                
               List<ClassA> unorderedCollection= new List<ClassA>() {
                   new ClassA() { ClassName = "B",  ClassId = 20, UID = new Guid(new byte[] {0,1,2,3,4,5,6,7,8,9,0xA,0xB,0xC,0xD,0xE,0xF})},
                   new ClassA() { ClassName =  "B", ClassId = 20, UID = new Guid(new byte[] {0,1,2,3,4,5,6,7,8,9,0xA,0xB,0xC,0xD,0xE,0xF})},
                   new ClassA() { ClassName =  "A", ClassId = 10, UID = new Guid(new byte[] {0,1,2,3,4,5,6,7,8,9,0xA,0xB,0xC,0xD,0xE,0xF})},
                   new ClassA() { ClassName =  "A", ClassId = 10, UID = new Guid(new byte[] {0,1,2,3,4,5,6,7,8,9,0xA,0xB,0xC,0xD,0xE,0xF})},
                   new ClassA() { ClassName =  "C", ClassId = 30, UID = new Guid(new byte[] {0,1,2,3,4,5,6,7,8,9,0xA,0xB,0xC,0xD,0xE,0xF})},
                   new ClassA() { ClassName =  "D", ClassId = 40, UID = new Guid(new byte[] {0,1,2,3,4,5,6,7,8,9,0xA,0xB,0xC,0xD,0xE,0xF})},
               };
               List<ClassA> results = unorderedCollection.OrderBy(x => x.ClassName).ThenBy(x => x.ClassId).ToList();
            }
        }
        public class ClassA
        {
            public String ClassName {get;set;}
            public int ClassId {get;set;}
            public Guid UID { get; set;  }
        }
    }
