    public interface IGrid {
        // ...
        public void setDefaults();
        // ...
    }
    public class ProjectModel : IGrid {
        // ...
        public void setDefaults() {
            PagerHelper.SetPage(1, 10);
            SortHelper.SetSort(SortOperator.Ascending);
            PagerHelper.RecordsPerPage = 10;            
        }    
        // ...
    }
