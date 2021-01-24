    public partial class ExcelViewTableAdapter
    {
        public int? UpdateReturnValue
        {
            get
            {
                int? insertVal = (int?)this._adapter.InsertCommand.Parameters["@NextNoteInfoID"].Value;
                int? updateVal = (int?)this._adapter.UpdateCommand.Parameters["@NextNoteInfoID"].Value;
                int? deleteVal = (int?)this._adapter.DeleteCommand.Parameters["@DeletedNoteIdentifier"].Value;
                if (insertVal != null && updateVal == null && deleteVal == null)
                {
                    return insertVal;
                }
                else if (updateVal != null && insertVal == null && deleteVal == null)
                {
                    return updateVal;
                }
                else if (deleteVal != null && insertVal == null && updateVal == null)
                {
                    return deleteVal;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
