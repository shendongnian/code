        public List<MyTable> RemoveAllInstancesOfDuplicates(List<MyTable> myTable)
        {
            List<MyTable> withoutAllInstancesOfDuplicates = new List<MyTable>();
            foreach(MyTable entry in myTable)
            {
                if (myTable.Count(row => 
                    string.Equals(row.Name, entry.Name) && 
                    string.Equals(row.Surname, entry.Surname)) == 1)
                {
                    withoutAllInstancesOfDuplicates.Add(entry);
                }
            }
            return withoutAllInstancesOfDuplicates;
        }
