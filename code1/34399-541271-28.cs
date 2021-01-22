     public class LookupCollection
     {
         private readonly IEnumerable<ILookupDTO> dtos;
         private ILookupList mList;
        
         public LookupCollection(IEnumerable<ILookupDTO> dtos)
         {
             this.dtos = dtos;
         }
        
         public void BindTo(ILookupList list)
         {
             mList = list;
            
             mList.Clear();
            
             foreach (ILookupDTO dto in dtos) {
                 mList.Add(dto);
             }
         }
        
         public int SelectedIndex {
             get { return mList.SelectedIndex; }
             set { mList.SelectedIndex = value; }
         }
        
         public string SelectedValue {
             get { return mList.SelectedValue; }
             set { mList.SelectedValue = value; }
         }
     }
