    var student = new Student { FirstName = "John", LastName = "Doe" };
    var mdoel = student.ToDTO();
    public static StudentViewModel ToDTO(this Student student)
    {
        var model = new StudentViewModel();
        model.FullName = $"{student.FirstName} {student.LastName}";
        return model;
    }
