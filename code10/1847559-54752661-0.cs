    using System;
    using System.Diagnostics;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    public class Info
    {
        public string NameField { get; set; }
        public bool Able { get; set; }
    }
    
    public class Do
    {
        public ObservableCollection<Info> Projects;
    
        public void SortProjects()
        {
            Projects = new ObservableCollection<Info>() {
                new Info { NameField="PER", Able = false},
                new Info { NameField="ALEX", Able = false},
                new Info { NameField="OSCAR", Able = false},
                new Info { NameField="ANDY", Able = false}
            };
    
            string sortCriteria = "OS";
    
            var change = Projects.OrderByDescending(c => c.NameField.StartsWith(sortCriteria)).ToList();
            Projects.Clear();
            foreach (Info aInfo in change)
            {
                //If .NameField is according to the search criteria .Able is sat true.
                aInfo.Able = aInfo.NameField.StartsWith(sortCriteria);
                //Adds the Info object.
                Projects.Add(aInfo);
            }
    
            foreach (Info i in Projects)
            {
                Debug.Print(i.NameField + "  -->  " + i.Able);
            }
        }
    }
