    public void AttachFile(byte[] byteArray)
                {
                    FileTable currentFileTable = new FileTable();                
                    currentFileTable.FileData = byteArray;
                    //Populate your other properties
                    _yourcontext.yourtable.Add(currentFileTable);
                    _yourcontext.SaveChanges();
        }
