    //-----------------------------------------------------------------------------------------
    //In the form - In constructor or form load, populate the grid.
    //--------------------------------------------------------------------------------------------
        
        List<student> students;
        private void PopulateList()
        {
            student std1 = new student("sss", 15, "Female");
            student std2 = new student("ddd", 12, "Male");
            student std3 = new student("zzz", 16, "Male");
            student std4 = new student("qqq", 14, "Female");
            student std5 = new student("aaa", 11, "Male");
            student std6 = new student("lll", 13, "Female");
            students = new List<student>();
            students.Add(std1);
            students.Add(std2);
            students.Add(std3);
            students.Add(std4);
            students.Add(std5);
            students.Add(std6);
            dataGridView1.DataSource = students;
        }
    //---------------------------------------------------------------------------------------------
    //Comparer class to perform sorting based on column name and sort order
    //---------------------------------------------------------------------------------------------
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
    //---------------------------------------------------------------------------------------------
    // Performing sort on click on Column Header
    //---------------------------------------------------------------------------------------------
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get the current column details
            string strColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
            SortOrder strSortOrder = getSortOrder(e.ColumnIndex);
            students.Sort(new StudentComparer(strColumnName, strSortOrder));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
            customizeDataGridView();
            dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
        }
       /// <summary>
        /// Get the current sort order of the column and return it
        /// set the new SortOrder to the columns.
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns>SortOrder of the current column</returns>
        private SortOrder getSortOrder(int columnIndex)
        {
            if (dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
            {
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
            }
            else
            {
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
            }
        }
