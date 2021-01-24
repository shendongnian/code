    public class EmployeeValidator : BaseValidator<EmployeeViewModel>
    {
        public EmployeeValidator(ValidationEntitySettingServices validationEntitySettingService) : base(validationEntitySettingService)
        {
            // no longer needed
            //AddEmptyRuleFor(x => x.LastName, "Last Name is a required field!");
            //AddEmptyRuleFor(x => x.FirstName, "First Name is a required field!");
            //AddEmptyRuleFor(x => x.MiddleName, "Middle Name is a required field!");
        }
    }
