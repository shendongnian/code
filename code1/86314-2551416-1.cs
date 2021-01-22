    class StudentComparer : IComparer<Student>
    {
        string memberName = string.Empty; // specifies the member name to be sorted
        SortOrder sortOrder = SortOrder.None; // Specifies the SortOrder.
        /// <summary>
        /// constructor to set the sort column and sort order.
        /// </summary>
        /// <param name="strMemberName"></param>
        /// <param name="sortingOrder"></param>
        public StudentComparer(string strMemberName, SortOrder sortingOrder)
        {
            memberName = strMemberName;
            sortOrder = sortingOrder;
        }
        /// <summary>
        /// Compares two Students based on member name and sort order
        /// and return the result.
        /// </summary>
        /// <param name="Student1"></param>
        /// <param name="Student2"></param>
        /// <returns></returns>
        public int Compare(Student Student1, Student Student2)
        {
            int returnValue = 1;
            switch (memberName)
            {
                case "Name" :
                    if (sortOrder == SortOrder.Ascending)
                    {
                        returnValue = Student1.Name.CompareTo(Student2.Name);
                    }
                    else
                    {
                        returnValue = Student2.Name.CompareTo(Student1.Name);
                    }
                    break;
                case "Sex":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        returnValue = Student1.Sex.CompareTo(Student2.Sex);
                    }
                    else
                    {
                        returnValue = Student2.Sex.CompareTo(Student1.Sex);
                    }
                    break;
                default:
                    if (sortOrder == SortOrder.Ascending)
                    {
                        returnValue = Student1.Name.CompareTo(Student2.Name);
                    }
                    else
                    {
                        returnValue = Student2.Name.CompareTo(Student1.StudentId);
                    }
                    break;
            }
            return returnValue;
        }
    }
