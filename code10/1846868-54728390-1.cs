    public class CategoryForReturnDto
    {
         public string Name { get; set; }
         public int Id { get; set; }
         public int ItemsCount { get; set; }
         public ICollection<CategoryForReturnDto> Children { get; set; }
         public int? ParentId { get; set; }
    }
