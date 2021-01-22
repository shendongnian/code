    [PersistChildren(false), ParseChildren(true)]
    public class ModalBox : CompositeControl
    {
    
      [PersistenceMode(PersistenceMode.InnerProperty)]
      [TemplateContainer(typeof(ContentsTemplate))]
      public ITemplate Contents { get; set; }
    
      [PersistenceMode(PersistenceMode.InnerProperty)]
      [TemplateContainer(typeof(ContentsTemplate))]
      public ITemplate Footer { get; set; }
    
      protected override void CreateChildControls()
      {
        Controls.Clear();
    
        var contentsItem = new ContentsTemplate();
        Contents.InstantiateIn(contentsItem);
        Controls.Add(contentsItem);
    
        var footerItem = new ContentsTemplate();
        Footer.InstantiateIn(footerItem);
        Controls.Add(footerItem);
      }
    
    }
