    public class DynamicRow : DynamicObject {
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            // this will be called when you access dynamic property
            // like x.some_column_name
            result = GetValue(binder.Name);
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value) {
            // this will be called when you assign dynamic property
            // like x.some_column_name = "some value"
            SetValue(binder.Name, value);
            return true;
        }
        private DataRow some_table;
        protected object GetValue(string columnName) {
            return some_table[columnName.Substring(columnName.IndexOf('_') + 1)];
        }
        protected object SetValue(string columnName, object value) {
            return some_table[columnName.Substring(columnName.IndexOf('_') + 1)] = value;
        }
    }
