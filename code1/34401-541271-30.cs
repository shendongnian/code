     public class WebLookupList : ILookupList
     {
        
         private readonly ListControl listControl;
        
         public WebLookupList(ListControl listControl)
         {
             this.listControl = listControl;
         }
        
         public void Clear()
         {
             listControl.Items.Clear();
         }
        
         public void Add(Interfaces.ILookupDTO dto)
         {
             listControl.Items.Add(new ListItem(dto.Text, dto.Value));
         }
        
         public int Count()
         {
             return listControl.Items.Count;
         }
        
         public int SelectedIndex {
             get { return listControl.SelectedIndex; }
             set { listControl.SelectedIndex = value; }
         }
        
         public string SelectedValue {
             get { return listControl.SelectedValue; }
             set { listControl.SelectedValue = value; }
         }
     }
