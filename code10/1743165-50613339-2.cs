    public class NavItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int navItemId { get; set; }
        public int? parentNavItemId { get; set; }
        public int sortOrder { get; set; }
        public bool isTitle { get; set; }
        public bool isDivider { get; set; }
        public string cssClass { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
        public string variant { get; set; }
        public string badgeText { get; set; }
        public string badgeVariant { get; set; }
        public NavItem parentNavItem { get; set; }
        public virtual ICollection<NavItem> children { get; set; }
    }
