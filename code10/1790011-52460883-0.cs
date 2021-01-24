    public class MyData
    {
        // I dont know your class structure so I added all data in the constructor
        public MyData()
        {   
            BookingVariants = new ObservableCollection<BookingVariant>();
            this.BookingVariants.Add(new BookingVariant() 
            { Title = "Title", BookingVariantURL = "myURL" });
            this.BookingVariants.Add(new BookingVariant() 
            { Title = "Title2", BookingVariantURL = "myURL2" });
            this.BookingVariants.Add(new BookingVariant() 
            { Title = "Title3", BookingVariantURL = "myURL3" });
        }
        public ObservableCollection<BookingVariant> BookingVariants
        {
            get;
            private set;
        }
    }
