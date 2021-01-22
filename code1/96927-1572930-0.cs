    public abstract class ListRenderer
    {
      public abstract IEnumerable Items {get;}
      public abstract String GenerateHeaderText();
      public String GenerateItemText(objectItem);
      public abstract void RenderList(TextWriter writer);
    }
