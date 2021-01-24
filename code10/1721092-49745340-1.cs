    public int Id { get; set; }
    public string EvaluationState { get; set; }
    public int LanguageId { get; set; }
    public virtual Language Language { get; set; }
    public int FacilityId { get; set; }
    public virtual Organization Facility { get; set; }
    public int TestSubjectId { get; set; }
    public virtual TestSubject TestSubject { get; set; }
