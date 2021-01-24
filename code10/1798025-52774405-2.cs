    public class EmployeeController
    {
        [Authorize("HR")]
        [HttpGet, Route("GetForHR")]
        public IActionResult Get(int employeeID)
        {
            // Note: this is just a sample out of my head, so there will be adjustments needed in order to run that
            // Check if the HR is allowed to access the Employees data
            // Get the Employee by its ID
            var emp = ...;
            // Convert it to the DTO
            var dto = Mapper.Map<DTOGetEmployee>(emp);
            // return the dto
            return Ok(dto);
        }
    }
