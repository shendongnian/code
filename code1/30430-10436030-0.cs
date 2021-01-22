    public class EnhancedComboBox : ComboBox 
    {
        [... the implementation]
        public void DoRefreshItems()
        {
            SetItemsCore(DataSource as IList);       
        }
    }
