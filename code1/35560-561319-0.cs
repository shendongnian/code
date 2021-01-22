      /// <summary>
      /// Backing store for the <see cref="ScrollViewer"/> property.
      /// </summary>
      private ScrollViewer scrollViewer;
    
      /// <summary>
      /// Gets the scroll viewer contained within the FlowDocumentScrollViewer control
      /// </summary>
      public ScrollViewer ScrollViewer
      {
         get
         {
            if (this.scrollViewer == null)
            {
               DependencyObject obj = this;
               do
               {
                  if (VisualTreeHelper.GetChildrenCount(obj) > 0)
                     obj = VisualTreeHelper.GetChild(obj as Visual, 0);
                  else
                     return null;
               }
               while (!(obj is ScrollViewer));
               this.scrollViewer = obj as ScrollViewer;
            }
            return this.scrollViewer;
         }
      }
