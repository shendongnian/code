      /// <summary>
      /// Hides PrintExtensions.IsPrintable="False" elements before printing,
      /// and get them back after. Not a production quality code.
      /// </summary>
      public static class PrintExtensions
      {
        private static readonly List<WeakReference> _trackedItems = new List<WeakReference>();
    
        public static bool GetIsPrintable(DependencyObject obj)
        {
          return (bool)obj.GetValue(IsPrintableProperty);
        }
    
        public static void SetIsPrintable(DependencyObject obj, bool value)
        {
          obj.SetValue(IsPrintableProperty, value);
        }
    
        public static readonly DependencyProperty IsPrintableProperty =
            DependencyProperty.RegisterAttached("IsPrintable",
            typeof(bool),
            typeof(PrintExtensions),
            new PropertyMetadata(true, OnIsPrintableChanged));
    
        private static void OnIsPrintableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          var printable = (bool)e.NewValue;
          bool isTracked = IsTracked(d);
          if (printable && !isTracked)
          {
            StartTracking(d);
          }
          else if (!printable && isTracked)
          {
            StopTracking(d);
          }
        }
    
        /// <summary>
        /// Call this method before printing.
        /// </summary>
        public static void OnBeforePrinting()
        {
          IterateTrackedItems(
            item =>
            {
              var fe = item.Target as FrameworkElement;
              if (fe != null)
              {
                fe.Visibility = Visibility.Collapsed; // Boom, we break bindings here, if there are any.
              }
            });
        }
    
        /// <summary>
        /// Call this after printing.
        /// </summary>
        public static void OnAfterPrinting()
        {
          IterateTrackedItems(
            item =>
            {
              var fe = item.Target as FrameworkElement;
              if (fe != null)
              {
                fe.Visibility = Visibility.Visible; // Boom, binding is broken again here.
              }
            });
        }
    
        private static void StopTracking(DependencyObject o)
        {
          // This is O(n) operation.
          var reference = _trackedItems.Find(wr => wr.IsAlive && wr.Target == o);
          if (reference != null)
          {
            _trackedItems.Remove(reference);
          }
        }
    
        private static void StartTracking(DependencyObject o)
        {
          _trackedItems.Add(new WeakReference(o));
        }
    
        private static bool IsTracked(DependencyObject o)
        {
          // Be careful, this function is of O(n) complexity.
          var tracked = false;
    
          IterateTrackedItems(
            item =>
            {
              if (item.Target == o)
              {
                tracked = true;
              }
            });
    
          return tracked;
        }
    
        /// <summary>
        /// Iterates over tracked items collection, and perform eachAction on
        /// alive items. Don't want to create iterator, because we do house
        /// keeping stuff here. Let it be more prominent.
        /// </summary>
        private static void IterateTrackedItems(Action<WeakReference> eachAction)
        {
          var trackedItems = new WeakReference[_trackedItems.Count];
          _trackedItems.CopyTo(trackedItems);
          foreach (var item in trackedItems)
          {
            if (!item.IsAlive) // do some house keeping work.
            {
              _trackedItems.Remove(item); // Don't care about GC'ed objects.
            }
            else
            {
              eachAction(item);
            }
          }
        }
      }
