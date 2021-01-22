    internal interface IStatusRecordsToMove
    {    
        List<IRecord> Records { get; }
    }
    internal interface IRecord
    {
        string Status { get; set; }
    }
    internal interface IRecordsMover
    {
        ITargetDb TargetDb { get; }
        void Move(IStatusRecordsToMove record);
    }
    internal interface ITargetDb
    {
        void SaveAndUpdateStatus(IRecord record);
    }
    class ProcessTableRecordsToMove : IStatusRecordsToMove
    {
        public List<IRecord> Records
        {
            get { throw new NotImplementedException(); }
        }
    }
    internal class ProcessRecordsMoverImpl : IRecordsMover
    {
        #region IRecordsMover Members
        public ITargetDb TargetDb
        {
            get { throw new NotImplementedException(); }
        }
        public void Move(IStatusRecordsToMove recordsToMove)
        {
            foreach (IRecord item in recordsToMove.Records)
            {
                TargetDb.SaveAndUpdateStatus(item);
            }
        }
        #endregion
    }
    internal class TargetTableBDb : ITargetDb
    {
        public void SaveAndUpdateStatus(IRecord record)
        {
            try
            {
                //some db object, save new record
                record.Status = "Success";
            }
            catch(ApplicationException)
            {
                record.Status = "Failed";
            }
            finally
            {
                //Update IRecord Status in Db
            }
        }
    }
