    using System.ComponentModel.DataAnnotations.Schema;
    ...
    public partial class SettingsPreference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int employeeNumber { get; set; }
        public string viewOrder { get; set; }
    }
