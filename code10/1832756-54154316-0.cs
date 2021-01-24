    [HttpGet]
    [Route("/api/employee/{id}/")]
    public Employee Get([FromRoute]int id)
    {
        using (EmployeeDBEntities entities = new EmployeeDBEntities())
        {
            return entities.Employees.FirstOrDefault(e => e.ID == id);
        }
    }
