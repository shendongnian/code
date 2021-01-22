    public class FunkyComboBox : ComboBox
    {
        private object currentValue = null;
        private List<string> innerItems = new List<string>();
        public FunkyComboBox()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
                innerItems.Add("Other...");
            this.DataSource = innerItems;
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (!this.Text.StartsWith("Other") && currentValue != this.SelectedItem)
            {
                currentValue = this.SelectedItem;
                BindingManagerBase bindingManager = DataManager;
                base.OnSelectedIndexChanged(e);
            }
        }
        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            string itemAsStr = this.SelectedItem != null ? SelectedItem.ToString() : "";
            if (itemAsStr.StartsWith("Other"))
            {
                string newItem = "item" + this.Items.Count;                
                if(!innerItems.Contains(newItem))
                {
                    innerItems.Add(newItem);
                    this.RefreshItems();
                } SelectedItem = newItem;
            }
            else
            {
                OnSelectedIndexChanged(e);
                //forces a selectedIndexChanged event to be thrown              
                base.OnSelectionChangeCommitted(e);
            }
        }
    }
