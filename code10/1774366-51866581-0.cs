    public class Member
    {
    public int Id { get; set; }
    public string MemberName { get; set; }
    //FK to Staff model which stores the ICC Staff Type value
    [ForeignKey("Staff")]
    public int? StaffId { get; set; }
    //FK to Staff model which stores the FP Staff Type value
    [ForeignKey("FPStaff")]
    public int? FPNumber { get; set; }
    //Navigation property 
    public virtual Staff Staff { get; set; }
    public virtual Staff FPStaff{ get; set; }
    }
