    [HasAndBelongsToMany(typeof(Book),
        Table = "BookCourse", ColumnKey = "course_id", ColumnRef = "book_id")]
        public IList Books
    
    [HasAndBelongsToMany(typeof(Course),
       Table = "BookCourse", ColumnKey = "book_id", ColumnRef = "course_id", Inverse = true)]
        public IList Courses
