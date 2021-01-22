    [ContentProperty("Children", true)] 
    public class MyRectangle : UIElement
    {
         public MyRectangle()
         {
              this.Children = new UIElementCollection();
              this.Children.Add(new System.Windows.Shapes.Rectangle());
         }
    
         public UIElementCollection Children {get; private set;}
    }
