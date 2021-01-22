    public partial class YourDataContext
    {
        partial void InsertYourEntity(YourEntity entity)
        {
            using (DbCommand cmd = this.Connection.CreateCommand())
            {
                ... // set the parameters and SP name here
                cmd.ExecuteNonQuery();
                entity.Id = (int) someParameter.Value;
            }
        }
    }
