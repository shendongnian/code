    IList<StudentViewModel> vm = new List<StudentViewModel>();
    using (var ctx = new StudentDBEntities())
    {
        var students = ctx.Students.Include("StudentAddress");
        foreach (var student in students)
        {
            var s = new StudentViewModel
            {
                Id = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
            };
            if(student.StudentAddress != null)
            {
                s.Address = new AddressViewModel
                {
                    StudentId = student.StudentAddress.StudentId,
                    Address1 = student.StudentAddress.Address1,
                    Address2 = student.StudentAddress.Address2,
                    City = student.StudentAddress.City,
                    State = student.StudentAddress.State
                 };
            });
            vm.Add(s);
        }
    }
    if (!vm.Any())
    {
       return NotFound();
    }
    return Ok(vm);
