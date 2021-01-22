    class BaseEntity {
      private readonly m_name as string;
      public Name { get { return m_name; } }
      protected BaseEntity(name as string) {
        m_name = name;
      }
    }
    class BlueEntity : BaseEntity {
      public BlueEntity() : base(typeof(BlueEntity).Name) {}
    }
