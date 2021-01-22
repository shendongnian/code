    public class Inventory
    {
        private IEnumerable<Departments> departments;
        private IEnumerable<Items> items;
    
        public Inventory ListDepartments()
        {
          // load up departments to a class level field
          return this;
        }
        public Inventory ListItems()
        {
          // load up items to a class level field
          return this;
        }
        
        public string ToHtml()
        {
          // convert whichever enumerable was previously loaded to HTML
          return stringBuilder.ToString();
        }
    }
