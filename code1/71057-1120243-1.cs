    public class Roster : INotifyPropertyChanged {
    
        public Roster ()
        {
            // Set the binding list, this triggers the appropriate
            // event binding which would be gotten if the BindingList
            // was set on assignment.
            People = new BindingList<Person>();
        }
    
        // The list of people.
        BindingList<Person> people = null;
    
        public BindingList<Person> People 
        {
            get 
            { 
                return people; 
            }
            set 
            { 
                // If there is a list, then remove the delegate.
                if (people != null)
                {
                    // Remove the delegate.
                    people.ListChanged -= OnListChanged;
                }
                /* Perform error check here */ 
                people = value;
    
                // Bind to the ListChangedEvent.
                // Use lambda syntax if LINQ is available.
                people.ListChanged += OnListChanged;
    
                // Technically, the People property changed, so that
                // property changed event should be fired.
                NotifyPropertyChanged("People");
    
                // Calculate the total age now, since the 
                // whole list was reassigned.
                CalculateTotalAge();
            }
        }
        private void OnListChanged(object sender, ListChangedEventArgs e)
        {
            // Just calculate the total age.
            CalculateTotalAge();
        }
    
        private void CalculateTotalAge()
        {
            // Store the old total age.
            int oldTotalAge = totalage;
    
            // If you can use LINQ, change this to:
            // totalage = people.Sum(p => p.Age);
    
            // Set the total age to 0.
            totalage = 0;
          
            // Sum.
            foreach (Person p in People) {
                totalage += p.Age;
            }
    
            // If the total age has changed, then fire the event.
            if (totalage != oldTotalAge)
            {
                // Fire the property notify changed event.
                NotifyPropertyChanged("TotalAge");
            }
        }
    
        private int totalage = 0;
    
        public int TotalAge 
        {
            get 
            {
                return totalage;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged ( String info ) {
            if ( PropertyChanged != null ) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
