      public static IEnumerable<T> AllControls<T>(this Control startingPoint) where T : Control
      {
         bool hit = startingPoint is T;
         if (hit)
         {
            yield return startingPoint as T;
         }
         foreach (var child in startingPoint.Controls.Cast<Control>())
         {
            foreach (var item in AllControls<T>(child))
            {
               yield return item;
            }
         }
      }
