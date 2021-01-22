    public class EditableRadioListAttribute : AbstractEditableAttribute
    {
        public override void UpdateEditor(N2.ContentItem item, Control editor)
        {
            RadioButtonList rbl = editor as RadioButtonList;
            if (rbl != null)
            {
                rbl.SelectedValue = item[this.Name].ToString();
                if (rbl.Items.FindByValue(item[this.Name].ToString()) != null)
                {
                    rbl.Items.FindByValue(item[this.Name].ToString()).Selected = true;
                }
            }
        }
    
        public override bool UpdateItem(N2.ContentItem item, Control editor)
        {
            RadioButtonList rbl = editor as RadioButtonList;
            string itemID = rbl.SelectedValue;
            item[this.Name] = itemID;
            return true;
        }
    
        protected override Control AddEditor(Control container)
        {
            RadioButtonList rbl = new RadioButtonList();
            var items = N2.Find.Items
                .Where.Type.Eq(typeof(TestItem))
                .Filters(new NavigationFilter())
                .Select<TestItem>();
            foreach (TestItem i in items)
            {
                rbl.Items.Add(new ListItem(i.Title, i.ID.ToString()));
            }
            container.Controls.Add(rbl);
            return rbl;
        }
    }
