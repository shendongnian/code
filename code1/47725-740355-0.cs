    public class Widgets
    {
      public Widget Add(string Path, Widget wdg)
      {
        // Chek it doesn't already exits and all...
        WidgetsByPath.Add(Path, wdg);
        PathsByWidget.Add(wdg, Path);
      }
    
      public void Delete(string Path)
      {
        Widget w = WidgetsByPath[Path];
        PathsByWidget.Delete(w);
        WidgetsByPath.Delete(Path);
      }
    }
