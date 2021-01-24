        private ConcurrentDictionary<int, DateTime> mappingTable;
        private bool ValidateAndUpdate(int id, DateTime entry)
        {
            try
            {
                if(!mappingTable.ContainsKey(id) && entry.TimeStamp > DateTime.Today.Date)
                {
                    mappingTable.TryAdd(id, entry);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception exception)
            {
                //handle exception event
            }
        }
        private void OnEntryWritten(object sender, EntryWrittenEventArgs e)
        {
			//preceding code here
			if(ValidateAndUpdate(e.Entry.Index, entry) == true)
            {
				//perform operation
            }
            catch(Exception exception)
            {
                //handle exception event
            }
        }
