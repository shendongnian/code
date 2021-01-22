     public interface ILookupList
     {
         void Add(ILookupDTO dto);
         void Clear();
         int Count();
         int SelectedIndex {
             get;
             set;
         }
         string SelectedValue {
             get;
             set;
         }
     }
