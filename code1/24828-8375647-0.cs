    public enum YesPartialNoEnum
    {
        [Description("Yes")]
        Yes,
        [Description("Still undecided")]
        Partial,
        [Description("No")]
        No
    }
    //........
    [Display(Name = "The label for my dropdown list")]
    public virtual Nullable<YesPartialNoEnum> CuriousQuestion{ get; set; }
    public virtual Nullable<int> CuriousQuestionId
    {
        get { return (Nullable<int>)CuriousQuestion; }
        set { CuriousQuestion = (Nullable<YesPartialNoEnum>)value; }
    }
