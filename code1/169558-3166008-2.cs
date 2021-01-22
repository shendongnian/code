    public partial class uspGetDepartmentsResult
    {
        private System.Nullable<int> _ParentDepartmentId;
        private System.Nullable<int> _DepartmentId;
        private string _DepartmentName;
        public uspGetDepartmentsResult() {}
        [global::System.Data.Linq.Mapping.ColumnAttribute(
            Storage="_ParentDepartmentId", DbType="Int")]
        public System.Nullable<int> ParentDepartmentId
        {
            get { return this._ParentDepartmentId; }
            set
            {
                if ((this._ParentDepartmentId != value))
                {
                    this._ParentDepartmentId = value;
                }
            }
        }
		
        [global::System.Data.Linq.Mapping.ColumnAttribute(
            Storage="_DepartmentId", DbType="Int")]
        public System.Nullable<int> DepartmentId
        { ... }
        [global::System.Data.Linq.Mapping.ColumnAttribute(
            Storage="_DepartmentName", DbType="NVarChar(200)")]
        public string DepartmentName
        { ... }
    }
