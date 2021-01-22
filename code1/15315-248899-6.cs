    // StudentList now implements IEnumerable<Student>
    public class StudentList : IEnumerable<Student>
    {
        // previous code omitted
        #region IEnumerable<Student> Members
        public IEnumerator<Student> GetEnumerator()
        {
            ListNode current = _firstElement;
    
            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }
        #endregion
    
        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
    
