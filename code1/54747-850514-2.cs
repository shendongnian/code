    [HasAndBelongsToMany(typeof(Book),
        Table = "BookCourse", ColumnKey = "course_id", ColumnRef = "book_id")]
        public IList<Book> Books
    
    [HasAndBelongsToMany(typeof(Course),
       Table = "BookCourse", ColumnKey = "book_id", ColumnRef = "course_id", Inverse = true)]
        public IList<Course> Courses
