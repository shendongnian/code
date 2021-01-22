    [ParseChildren(true), PersistChildren(false)]
    public class Repeater : Control, INamingContainer
    {
      [PersistenceMode(PersistenceMode.InnerProperty)]
      public virtual ITemplate HeaderTemplate { get; set; }
      [PersistenceMode(PersistenceMode.InnerProperty)]
      public virtual ITemplate ItemTemplate { get; set; }
    }
