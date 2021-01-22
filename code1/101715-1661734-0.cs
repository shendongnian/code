    public class PositionProviderRepository
    {
        public List<T> GetList()
            {
                int positionTypeId = (int)this.PositionType;
                using (SqlConnection cn = new SqlConnection(Globals.Instance.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Get_PositionListByPositionTypeId", cn);
                    cmd.Parameters.Add("@PositionTypeId", SqlDbType.Int).Value = positionTypeId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    return this.GetCollectionFromReader(this.ExecuteReader(cmd));
                }
            }
        public List<CustomerEntity> GetCustomersByUserPermission(Guid userId) {
          //TODO: implementation
        }
    }
