    public interface ICanBindToObjectsKeyValuePair {
        void BindToProperties<TYPE_TO_BIND_TO>(IEnumerable<TYPE_TO_BIND_TO> bindableEnumerable, Expression<Func<TYPE_TO_BIND_TO, object>> textProperty, Expression<Func<TYPE_TO_BIND_TO, object>> valueProperty);
    }
    
    public class EasyBinderDropDown : DropDownList, ICanBindToObjectsKeyValuePair {
        public EasyBinderDropDown() {
            base.AppendDataBoundItems = true;
        }
        public void BindToProperties<TYPE_TO_BIND_TO>(IEnumerable<TYPE_TO_BIND_TO> bindableEnumerable,
            Expression<Func<TYPE_TO_BIND_TO, object>> textProperty, Expression<Func<TYPE_TO_BIND_TO, object>> valueProperty) {
            if (ShowSelectionPrompt)
                Items.Add(new ListItem(SelectionPromptText, SelectionPromptValue));
            base.DataTextField = textProperty.MemberName();
            base.DataValueField = valueProperty.MemberName();
            base.DataSource = bindableEnumerable;
            base.DataBind();
        }
        public bool ShowSelectionPrompt { get; set; }
        public string SelectionPromptText { get; set; }
        public string SelectionPromptValue { get; set; }
        public virtual IEnumerable<ListItem> ListItems {
            get { return Items.Cast<ListItem>(); }
        }
    }
