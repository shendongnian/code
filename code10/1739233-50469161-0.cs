      public class Screen
      {
          public Guid ID { get; set; }
          public bool IsCheck { get; set; }
          public Guid ParentID { get; set; }
          public bool IsActive { get; set; }
          public Screen Parent { get; set; }
          public ICollection<Screen> Children { get; set; }
          public RoleScreen RoleScreen { get; set; }
      }
      public class RoleScreen
      {
          public Guid ID { get; set; }
          public Guid RoleID { get; set; }
          public Guid ScreenID { get; set; }
          public Screen Screen { get; set; }
      }
