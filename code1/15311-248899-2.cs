    public class StudentList 
    {
        private ListNode _firstElement; // always need to keep track of the head.
        private class ListNode
        {
            public Student Element { get; set; }
            public ListNode Next { get; set; }
        }
        public void Add(Student student) { /* TODO */ }
    }
