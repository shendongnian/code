    public partial class Work
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int WorkerId { get; set; }
    public Worker Worker { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartingTime { get; set; }
    public float Duration { get; set; }
    public string Note { get; set; }
    }
