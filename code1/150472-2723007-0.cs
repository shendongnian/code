    public partial class Person
    {
        public Person()
        {
            this.PropertyChanged += 
               new PropertyChangedEventHandler(Person_PropertyChanged);
        }
    
        protected void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // your code here
        }
    }
