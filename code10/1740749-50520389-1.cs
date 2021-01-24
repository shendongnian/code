    public override void OnActionExecuting(ActionExecutingContext context)
    {
        NoValidationAttribute.RemoveValidation(context);
        
        // Finally validation passes for properties using the [NoValidateAttribute]
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
    // Model using the NoValidationAttribute
    public class ExcelEmployeeModel
    {
        [Required] public String Description { get; set; }
        public List<Employee> Accepted { get; set; }
        [NoValidation]
        public List<Employee> RejectedEmployees { get; set; }
    }
