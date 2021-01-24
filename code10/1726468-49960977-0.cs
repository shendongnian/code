    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace GamerInMvc.Tests
    {
        [TestClass]
        public class UnitTest1
        {
    
            public Dictionary<string, Type> projectNames = new Dictionary<string, Type>();
    
            [TestMethod]
            public void TestMethod1()
            {
                // Create a list of parts.
                List<Project> parts = new List<Project>();
    
                // Add parts to the list.
                parts.Add(new Project() { ProjectName = "crank arm", ProjectId = 1234 });
                parts.Add(new Project() { ProjectName = "chain ring", ProjectId = 1334 });
                parts.Add(new Project() { ProjectName = "regular seat", ProjectId = 1434 });
                parts.Add(new Project() { ProjectName = "banana seat", ProjectId = 1444 });
                parts.Add(new Project() { ProjectName = "cassette", ProjectId = 1534 });
                parts.Add(new Project() { ProjectName = "shift lever", ProjectId = 1634 }); ;
    
                // Write out the parts in the list. This will call the overridden ToString method
                // in the Part class.
                Console.WriteLine();
                foreach (Project aPart in parts)
                {
                    Console.WriteLine(aPart);
                }
    
    
                // Check the list for part #1734. This calls the IEquatable.Equals method
                // of the Part class, which checks the PartId for equality.
                Console.WriteLine("\nContains: Project with Id=1734: {0}",
                    parts.Contains(new Project { ProjectId = 1734, ProjectName = "" }));
    
                // Find items where name contains "seat".
                Console.WriteLine("\nFind: Project where name contains \"seat\": {0}",
                    parts.Find(x => x.ProjectName.Contains("seat")));
    
                // Check if an item with Id 1444 exists.
                Console.WriteLine("\nExists: Project with Id=1444: {0}",
                    parts.Exists(x => x.ProjectId == 1444));
    
            }
    
        }
    
        public class Project : IEquatable<Project>
        {
            public int ProjectId { get; set; }
            public bool Academic { get; set; }
            public string ProjectName { get; set; }
            public string Equipment { get; set; }
            public bool Commercial { get; set; }
    
            public List<string> User = new List<string>();
            public List<int> Hours = new List<int>();
    
            public Project()
            {
                //parameterless ctor for demo
            }
    
            public Project(bool academic, string projectName, string equipment, List<string> user, List<int> hours)
            {
                Academic = academic;
                ProjectName = projectName;
                Equipment = equipment;
                User = user;
                hours = Hours;
            }
    
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                Project objAsPart = obj as Project;
                if (objAsPart == null) return false;
                else return Equals(objAsPart);
            }
            public override int GetHashCode()
            {
                return ProjectId;
            }
            public bool Equals(Project other)
            {
                if (other == null) return false;
                return (this.ProjectId.Equals(other.ProjectId));
            }
        }
         
    }
