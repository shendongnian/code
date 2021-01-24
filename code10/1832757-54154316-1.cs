    [HttpGet]
    [Route("/api/employee/{id}/")]
    public Employee Get([FromRoute]int id)
    {
        using (EmployeeDBEntities entities = new EmployeeDBEntities())
        {
            return entities.Employees.FirstOrDefault(e => e.ID == id);
        }
    }
EDIT: Not sure if i understood that question correctly, but if you are trying to get an employee from the database by id, that's the way to go. Everything concerning your employees should happen through the EmployeeController.
