        public interface IDocument 
        {
            string Id {get; set;}
            string Title {get; set;}
        }
        public class SearchCriteria
        {
            public Nullable<int> Id;
            public string Title;
        }
        public IEnumerable<IDocument> Search(SearchCriteria predicate)
        {
            if (predicate.Id.HasValue)
                //...make ID search
            else if (!string.IsNullOrEmpty(predicate.Title))
                //...search by title
            else
                // other kind of search
        }
