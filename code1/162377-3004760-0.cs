       protected override Size ArrangeOverride(Size arrangeSize)
       {
         //...
         if (padding.Equals(new Thickness()))
         {
           padding = DefaultPadding;
         }
         //...
         child.Arrange(new Rect(padding.Left, padding.Top, childWidth, childHeight));
       }
