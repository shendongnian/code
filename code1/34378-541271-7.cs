     public class WPFLookupList : ILookupList
     {
        
         private readonly ComboBox combobox;
        
         public WPFLookupList(ComboBox combobox)
         {
             this.combobox = combobox;
         }
        
         public void Add(Interfaces.ILookupDTO dto)
         {
             ComboBoxItem item = new ComboBoxItem();
             item.Content = dto.Text;
             item.Tag = dto.Value;
            
             combobox.Items.Add(item);
         }
        
         public void Clear()
         {
             combobox.Items.Clear();
         }
        
         public int Count()
         {
             return combobox.Items.Count;
         }
        
         public int SelectedIndex {
             get { return combobox.SelectedIndex; }
             set { combobox.SelectedIndex = value; }
         }
        
         public string SelectedValue {
             get { return combobox.SelectedValue.Tag; }
             set { combobox.SelectedValue.Tag = value; }
         }
     }
