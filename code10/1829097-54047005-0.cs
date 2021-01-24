    public void AttachFile(byte[] byteArray, int objectID)
            {
                FileTable currentFileTable = new FileTable();
                currentFileTable = _yourcontext.yourtable.Where(e => e.ID == objectID).FirstOrDefault();
                currentFileTable.FileData = byteArray;
                _yourcontext.yourtable.Update(currentFileTable);
                _yourcontext.SaveChanges();
    }
