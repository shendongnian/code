    Category 1:
    ID  CategoryLevel1Name 
    1   PC
    2   Laptop
    3   Mac
    Category 2:
    ID  CategoryLevel1Id CategoryLevel2Name 
    1   1                AllInOne
    2   1                Classic PC
    3   2                NetBook
    4   2                Class Laptop
    5   3                MacBook Pro
    public class Category1
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CategoryLevel1Name { get; set; }
        public ICollection<Category2> Category2s { get; set; }
    }
    public class Category2
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryLevel1Id { get; set; }
        public string CategoryLevel2Name { get; set; }
        [ForeignKey("CategoryLevel1Id ")]
        public Category1 Category1 { get; set; }
    }
