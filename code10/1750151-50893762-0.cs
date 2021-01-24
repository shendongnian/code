    using Microsoft.Toolkit.Uwp.UI;
    
    // Grab a sample type
    public class Person
    {
        public string Name { get; set; }
    }
    
    // Set up the original list with a few sample items
    var oc = new ObservableCollection<Person>
    {
        new Person { Name = "Staff" },
        new Person { Name = "42" },
        new Person { Name = "Swan" },
        new Person { Name = "Orchid" },
        ...
    };
    
    // Set up the AdvancedCollectionView with live shaping enabled to filter and sort the original list
    var acv = new AdvancedCollectionView(oc, true);
    
    // Let's filter out the integers
    int nul;
    acv.Filter = x => !int.TryParse(((Person)x).Name, out nul);
    
    // And sort ascending by the property "Name"
    acv.SortDescriptions.Add(new SortDescription("Name", SortDirection.Ascending));
    
    // Let's add a Person to the observable collection
    var person = new Person { Name = "Aardvark" };
    oc.Add(person);
    
    // Our added person is now at the top of the list, but if we rename this person, we can trigger a re-sort
    person.Name = "Zaphod"; // Now a re-sort is triggered and person will be last in the list
    
    // AdvancedCollectionView can be bound to anything that uses collections. 
    YourListView.ItemsSource = acv;
