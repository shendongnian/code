    public class IncomingData
    {
    [Key]
    [Required]
    public int Id { get; set; }
    ...
    public History History { get; set; }
    }
    public class History
    {
    [Key]
    public int Id { get; set; }
    ...
    [InverseProperty("Id")]
    public IncomingData IncomingData { get; set; }
    }
