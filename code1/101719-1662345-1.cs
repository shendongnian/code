    public class SqlCustomerProvider : CustomerProvider
    {
        public override List<CustomerEntity> GetCustomersByUserPermission(Guid userId)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Instance.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetRP_CustomersByUser", cn);
                cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return this.GetCollectionFromReader(this.ExecuteReader(cmd));
            }
        }
    }
