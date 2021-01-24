    private List<Student> students;
    //...
    public void LoadStudents() {
        // get data
        var data = _studentDomainContext.GetStudents();
        students = data.ToList();
        //...
    }
