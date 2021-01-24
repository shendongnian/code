    using System.Linq;
    using System.Diagnostics;
    using System.Collections.ObjectModel;
    
    
    namespace TestSpace
    {
        public class Info //Your original class for the project info objects.
        {
            public string NameField { get; set; }
            public bool Able { get; set; }
        }
    
        public class ProjectSorter  //COMMENT: Renamed your "Do" class to "ProjectSorter" since it seems more understandable.
        {
            // COMMENT:
            // In this proposed solution the SortProjects method is changed so that it now takes two parameters.        
            // The parameters are the project collection to be sorted, and the sort/search criteria.The procject  
            // collection to be sorterd is sent by ref so that any changes to it is reflected back to the caller.
            // (See https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref for more
            // information on passing objects by ref.)
    
            public void SortProjects(ref ObservableCollection<Info> projectCollectionToSort, string sortCriteria)
            {
                // As allready solved this will sort the collection based on the sort criteria into a new list.
                var updatedProjectList =
                projectCollectionToSort.OrderByDescending(c => c.NameField.StartsWith(sortCriteria)).ToList();
    
                // Using the list's .ForeEach method we iterate through the new list and uses a lambda expression
                // to set .Able to true or false based on the sort/search criteria.
                updatedProjectList.ForEach(c => {
                    if (c.NameField.StartsWith(sortCriteria)) { c.Able = true; } else { c.Able = false; }
                });
    
                // We then resets our collection to a new ObservableCollection<Info> and fills it with the new 
                // sorted and updated list.
                projectCollectionToSort = new ObservableCollection<Info>(updatedProjectList);
    
                // Work done.
            }
        }
    
        public static class TestTheCode
        {
            // Method to test the ProjectSorter.SortProjects() method.
            public static void RunSortCollectionTest()
            {
                ProjectSorter projectSorter = new ProjectSorter();
    
                // Just for the purpose of this example an example collection is populated
                // here with some data to work with.
                // As you describe for your list the default value for Able is set to true.
                ObservableCollection<Info> projects = new ObservableCollection<Info>()
                {
                    new Info { NameField="PER", Able = true},
                    new Info { NameField="ALEX", Able = true},
                    new Info { NameField="OSCAR", Able = true},
                    new Info { NameField="ANDY", Able = true}
                };
    
                // We sorts the collection "projects" by sending it by ref to the projectSorter.SortProjects()
                // method, together with the sort/search criteria.
                projectSorter.SortProjects(ref projects, "OS");
    
                // To display that the collection "projects" are now sorted as intended, and that all the
                // .Able fields are satt correctly true or false, we iterate through the projects collection 
                // and print the values for NameField and Able to the Output window (debug).
                foreach (Info aInfo in projects)
                {
                    Debug.Print(aInfo.NameField + "  -->  " + aInfo.Able);
                }
            }
        }
    }
