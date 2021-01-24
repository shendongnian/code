    public class EmployeeMetaData
        {
          
            [CheckDate(ErrorMessage = "Date should not past")]
            public string StartDate { get; set; }
        }
    
        [MetadataType(typeof(EmployeeMetaData))]
        public partial class Employee
        {
    
        }
