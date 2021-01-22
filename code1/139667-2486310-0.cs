     public class FilePathCollection :  IList<string>
        {
            string baseDirectory;
            private List<string> internalList;
    
            public FilePathCollection(string baseDirectory)
            {
                this.baseDirectory = baseDirectory;
            }
    
            #region IList<string> Members
    
            public int IndexOf(string item)
            {
                return GetFileNameOnly(internalList.IndexOf(item));
            }
            private string GetFileNameOnly(string p)
            {
                //your implementation.......
                throw new NotImplementedException();
            }
    
            private int GetFileNameOnly(int p)
            {
               //your implementation.......
                throw new NotImplementedException();
            }
    
            public void Insert(int index, string item)
            {
                internalList.Insert(index, item);
            }
    
            public void RemoveAt(int index)
            {
                internalList.RemoveAt(index);
            }
    
            public string this[int index]
            {
                get
                {
                    return GetFileNameOnly(internalList[index]);
                }
                set
                {
                    this[index] = value;
                }
            }
    
            
    
            #endregion
    
            #region ICollection<string> Members
    
            public void Add(string item)
            {
                internalList.Add(item);
            }
    
            public void Clear()
            {
                internalList.Clear();
            }
    
            public bool Contains(string item)
            {
                return internalList.Contains(item);
            }
    
            public void CopyTo(string[] array, int arrayIndex)
            {
                internalList.CopyTo(array, arrayIndex);
            }
    
            public int Count
            {
                get { return internalList.Count; }
            }
    
            public bool IsReadOnly
            {
                get { return false; }
            }
    
            public bool Remove(string item)
            {
                return internalList.Remove(item);
            }
    
            #endregion
    
            #region IEnumerable<string> Members
    
            public IEnumerator<string> GetEnumerator()
            {
                foreach(string value in internalList)
                    yield return baseDirectory + value;
            }
    
            #endregion
    
            #region IEnumerable Members
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                foreach(string value in internalList) 
                    yield return baseDirectory + value;
            }
    
            #endregion
        }
