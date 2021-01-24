    private List<Student> students;
    //...
    public void LoadStudents() {
        // get data
        students = _studentDomainContext.GetStudents();
        //...
    }
