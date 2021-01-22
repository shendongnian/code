        public bool HasChanges()
        {
            bool Result = false;
            myBindingSource.EndEdit();
            Result = ((DataTable)myBindingSource.DataSource).GetChanges(DataRowState.Modified) != null;
            
            return Result;
        }
