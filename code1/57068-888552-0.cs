    public class ListOfBusinesses : List<Business> {
        public ListOfBusinesses() : base() {
            Add(new Business("1", "Business Name 1"));
            Add(new Business("2", "Business Name 2"));
        }
    }
