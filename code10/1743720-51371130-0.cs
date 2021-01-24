    public class OrgChartNode
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(0, 6)]
        public int TierId { get; set; }
        public int? ParentGroupId { get; set; }
        [MaxLength(50)]
        public string OrgName { get; set; }
        [MaxLength(5)]
        public string OrgCode { get; set; }
        [MaxLength(100)]
        public string ContactName { get; set; }
        [MaxLength(255)]
        public string ContactEmail { get; set; }
        [MaxLength(12)]
        public string ContactPhone { get; set; }
        public int? ContactId { get; set; }
        public int? GroupTypeId { get; set; }
    }
