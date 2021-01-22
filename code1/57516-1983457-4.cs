    public class PersonFormViewModel
    {
      public SelectList Departments { get; set: }
      public Person Pers { get; set; }
      public PersonFormViewModel(Person p, List<Department> departments)
      {
        this.Pers = p;
        this.Departments = new SelectList(departments, "Id", "Name", p.DepartmentId);
      }
    }
