    public enum DisplayStatus {
        [Display(Name = "ACTIVE")]
        Active= 1,
        [Display(Name = "DELETED")]
        Deleted = 11
    }
    public class Vehicle_DTO {
        [EnumDataType(typeof(DisplayStatus))]
        [Display(Name = "STATUS")]
        public int Status { get; set; }
    }
    // ...
    gridControl1.DataSource = new List<Vehicle_DTO> {
        new Vehicle_DTO() { Status = 1 },
        new Vehicle_DTO() { Status = 11 },
        new Vehicle_DTO() { Status = 11 },
    };
