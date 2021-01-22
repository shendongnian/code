	public partial class ExampleDBtable: EntityObject, Audit.IAuditable
	{
         //Normal EDMX stuff here..
         public static ExampleDBtable CreateExampleDBtable(int id, string code, string name, DateTime insertedOn, string insertedBy, DateTime updatedOn, string updatedBy)
           {
           }
           //Extension points.
        #region IAuditable Members
        public void SetInsertedOn(DateTime date)
        {
            this._InsertedOn = date;
        }
        public void SetInsertedBy(string user)
        {
            this._InsertedBy = user;
        }
        public void SetUpdatedOn(DateTime date)
        {
            this._UpdatedOn = date;
        }
        public void SetUpdatedBy(string user)
        {
            this._UpdatedBy = user;
        }
        #endregion
        }
