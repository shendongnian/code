    public class DummyDataTemplateSelector : DataTemplateSelector
    {
      public DataTemplate ValidTemplate { get; set; }
      public DataTemplate InvalidTemplate { get; set; }
    
      protected override DataTemplate OnSelectTemplate (object item, BindableObject container)
      {
        return ((YourClass)item).YourProperty == Admin ? TemplateColor1 : TemplateColor2;
      }
    }
