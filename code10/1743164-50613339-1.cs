    public class NavItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NavItemId { get; set; }
        public int? ParentNavItemId { get; set; }
        public int SortOrder { get; set; }
        public bool IsTitle { get; set; }
        public bool IsDivider { get; set; }
        public string CssClass { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Variant { get; set; }
        public string BadgeText { get; set; }
        public string BadgeVariant { get; set; }
        public NavItem ParentNavItem { get; set; }
        public virtual ICollection<NavItem> Children { get; set; }
    }
