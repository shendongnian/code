//Dumping ground for miscellaneous functions
public static class Misc
{
   //Swap items at index positions 'index0' and 'index1' in the list
   public static void Swap&lt;T&gt;(this BindingList&lt;T&gt; list, int index0, int index1, bool reset_bindings)
   {
      if (index0 == index1) return;
      bool raise_events = list.RaiseListChangedEvents;
      try
      {
         list.RaiseListChangedEvents = false;
         T tmp = list[index0];
         list[index0] = list[index1];
         list[index1] = tmp;
         list.RaiseListChangedEvents = raise_events;
         if (reset_bindings) list.ResetBindings();
      }
      finally
      {
         list.RaiseListChangedEvents = raise_events;
      }
   }
}
