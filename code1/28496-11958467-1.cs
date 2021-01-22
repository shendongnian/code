    ==============NullReferenceException was thrown 12 times
    System.NullReferenceException: Object reference not set to an instance of an object.
       at System.Data.DataTable.RestoreIndexEvents(Boolean forceReset)
       at System.Data.DataTable.AcceptChanges()
       at System.Data.DataSet.AcceptChanges()
       at System.J.<>c__DisplayClass1.<Main>b__0(Int32 i, ParallelLoopState s) in Program.cs:line 104
    ==============ConstraintException was thrown 35 times
    System.Data.ConstraintException: Column 'Id' is constrained to be unique.  Value '392' is already present.
       at System.Data.UniqueConstraint.CheckConstraint(DataRow row, DataRowAction action)
       at System.Data.DataTable.RaiseRowChanging(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction, Boolean fireEvent)
       at System.Data.DataTable.SetNewRecordWorker(DataRow row, Int32 proposedRecord, DataRowAction action, Boolean isInMerge, Boolean suppressEnsurePropertyChanged, Int32 position, Boolean fireEvent, Exception& deferredException)
       at System.Data.DataTable.InsertRow(DataRow row, Int64 proposedID, Int32 pos, Boolean fireEvent)
       at System.Data.DataRowCollection.Add(DataRow row)
       at System.J.<>c__DisplayClass1.<Main>b__0(Int32 i, ParallelLoopState s) in Program.cs:line 111
    ==============InvalidOperationException was thrown 28 times
    System.InvalidOperationException: DataTable internal index is corrupted: '13'.
       at System.Data.RBTree`1.GetNodeByIndex(Int32 userIndex)
       at System.Data.Index.DeleteRecord(Int32 recordIndex, Boolean fireEvent)
       at System.Data.Index.ApplyChangeAction(Int32 record, Int32 action, Int32 changeRecord)
       at System.Data.Index.RecordStateChanged(Int32 record, DataViewRowState oldState, DataViewRowState newState)
       at System.Data.DataTable.RecordStateChanged(Int32 record1, DataViewRowState oldState1, DataViewRowState newState1, Int32 record2, DataViewRowState oldState2, DataViewRowState newState2)
       at System.Data.DataTable.SetNewRecordWorker(DataRow row, Int32 proposedRecord, DataRowAction action, Boolean isInMerge, Boolean suppressEnsurePropertyChanged, Int32 position, Boolean fireEvent, Exception& deferredException)
       at System.Data.DataRow.Delete()
       at System.J.<>c__DisplayClass1.<Main>b__0(Int32 i, ParallelLoopState s) in Program.cs:line 103
    ==============DeletedRowInaccessibleException was thrown 1 times
    System.Data.DeletedRowInaccessibleException: Deleted row information cannot be accessed through the row.
       at System.Data.DataRow.GetDefaultRecord()
       at System.Data.DataRow.GetKeyValues(DataKey key, DataRowVersion version)
       at System.Data.ForeignKeyConstraint.CascadeDelete(DataRow row)
       at System.Data.ForeignKeyConstraint.CheckCascade(DataRow row, DataRowAction action)
       at System.Data.DataTable.CascadeAll(DataRow row, DataRowAction action)
       at System.Data.DataTable.RaiseRowChanging(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction, Boolean fireEvent)
       at System.Data.DataTable.SetNewRecordWorker(DataRow row, Int32 proposedRecord, DataRowAction action, Boolean isInMerge, Boolean suppressEnsurePropertyChanged, Int32 position, Boolean fireEvent, Exception& deferredException)
       at System.Data.DataRow.Delete()
       at System.J.<>c__DisplayClass1.<Main>b__0(Int32 i, ParallelLoopState s) in Program.cs:line 103
    ==============ArgumentException was thrown 1 times
    System.ArgumentException: Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.
       at System.Data.RBTree`1.CopyTo(K[] array, Int32 index)
       at System.Data.DataTable.AcceptChanges()
       at System.Data.DataSet.AcceptChanges()
       at System.J.<>c__DisplayClass1.<Main>b__0(Int32 i, ParallelLoopState s) in Program.cs:line 104
    ==============VersionNotFoundException was thrown 1 times
    System.Data.VersionNotFoundException: There is no Current data to access.
       at System.Data.DataRow.GetRecordFromVersion(DataRowVersion version)
       at System.Data.ForeignKeyConstraint.CascadeDelete(DataRow row)
       at System.Data.ForeignKeyConstraint.CheckCascade(DataRow row, DataRowAction action)
       at System.Data.DataTable.CascadeAll(DataRow row, DataRowAction action)
       at System.Data.DataTable.RaiseRowChanging(DataRowChangeEventArgs args, DataRow eRow, DataRowAction eAction, Boolean fireEvent)
       at System.Data.DataTable.SetNewRecordWorker(DataRow row, Int32 proposedRecord, DataRowAction action, Boolean isInMerge, Boolean suppressEnsurePropertyChanged, Int32 position, Boolean fireEvent, Exception& deferredException)
       at System.Data.DataRow.Delete()
       at System.J.<>c__DisplayClass1.<Main>b__0(Int32 i, ParallelLoopState s) in Program.cs:line 103
    ==============RowNotInTableException was thrown 7 times
    System.Data.RowNotInTableException: Cannot perform this operation on a row not in the table.
       at System.Data.DataTable.SetOldRecord(DataRow row, Int32 proposedRecord)
       at System.Data.DataTable.CommitRow(DataRow row)
       at System.Data.DataRow.AcceptChanges()
       at System.Data.DataTable.AcceptChanges()
       at System.Data.DataSet.AcceptChanges()
       at System.J.<>c__DisplayClass1.<Main>b__0(Int32 i, ParallelLoopState s) in Program.cs:line 104
