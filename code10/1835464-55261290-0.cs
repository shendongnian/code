    public class Property
    {
      [NotMapped] 
      public virtual ICollection<PropertyUrl> Property_URLs { get; set; }
      [NotMapped]
      public virtual ICollection<BrochureData> Property_Brochures { get; set; }
      [NotMapped]
      public virtual ICollection<ImageSortOrder> Property_ImageSortOrders { get; set;}
    }
