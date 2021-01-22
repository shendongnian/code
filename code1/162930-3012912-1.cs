    namespace Adapters.UserTableAdapters
    {
        public partial class UsersTableAdapter : global::System.ComponentModel.Component
        {
            public UsersTableAdapter(string connectionString)
            {
                this._clearBeforeFill = true;
                this._connection = new System.Data.SqlClient.SqlConnection();
                this._connection.ConnectionString = connectionString;
            }
        }
    }
