    [Table("Commitment")]
    public class Commitment : FullAuditedEntity<Guid>, 
    {
        public string Property1 { get; set; }
        public Foo Foo { get; set; }
        public Guid FooId { get; set; }
    }
    [AutoMapFrom(typeof(Commitment))]
    [AutoMapTo(typeof(Commitment), MemberList = AutoMapper.MemberList.Source)]
    public class CommitmentDto : EntityDto<Guid>
    {
        public string Property1 { get; set; }
        public Foo Foo { get; set; }
        public Guid FooId { get; set; }
    }
