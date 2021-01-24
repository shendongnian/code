    public static Student MapPerson(StudentDto studentDto)
    {
        return Mapper.Map<StudentDto, Student>(studentDto);
    }
    public static Employe MapPerson(EmployeDto employeDto)
    {
        return Mapper.Map<EmployeDto, Employe>(employeDto);
    }
