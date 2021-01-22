    public class EditableCheckBoxListAttribute : AbstractEditableAttribute
    {
        public override void UpdateEditor(N2.ContentItem item, Control editor)
        {
            CheckBoxList lst = editor as CheckBoxList;
            if (lst != null)
            {
                foreach(ListItem li in lst.Items)
                {
                    if (item[this.Name].ToString().Contains(li.Value))
                    {
                        li.Selected = true;
                    }
                }
            }
        }
    
        public override bool UpdateItem(N2.ContentItem item, Control editor)
        {
            CheckBoxList lst = editor as CheckBoxList;
            ArrayList items = new ArrayList();
            foreach (ListItem li in lst.Items)
            {
                if (li.Selected)
                {
                   items.Add(li.Value);
                }
            }
            string[] itemID = (string[])items.ToArray(typeof(string));
            item[this.Name] = String.Join(",",itemID);
            return true;
        }
    
        protected override Control AddEditor(Control container)
        {
            CheckBoxList lst = new CheckBoxList();
            var items = N2.Find.Items
                .Where.Type.Eq(typeof(TestItem))
                .Filters(new NavigationFilter())
                .Select<TestItem>();
            foreach (TestItem i in items)
            {
                lst.Items.Add(new ListItem(i.Title, i.ID.ToString()));
            }
            container.Controls.Add(lst);
            return lst;
        }
    }
