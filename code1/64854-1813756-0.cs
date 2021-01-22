    public static class BindingSourceExtension
    {
        public static void MoveUp( this BindingSource aBindingSource )
        {
            int position = aBindingSource.Position;
            if (position == 0) return;  // already at top
            aBindingSource.RaiseListChangedEvents = false;
            object current = aBindingSource.Current;
            aBindingSource.Remove(current);
            position--;
            aBindingSource.Insert(position, current);
            aBindingSource.Position = position;
            aBindingSource.RaiseListChangedEvents = true;
            aBindingSource.ResetBindings(false);
        }
        public static void MoveDown( this BindingSource aBindingSource )
        {
            int position = aBindingSource.Position;
            if (position == aBindingSource.Count - 1) return;  // already at bottom
            aBindingSource.RaiseListChangedEvents = false;
            object current = aBindingSource.Current;
            aBindingSource.Remove(current);
            position++;
            aBindingSource.Insert(position, current);
            aBindingSource.Position = position;
            aBindingSource.RaiseListChangedEvents = true;
            aBindingSource.ResetBindings(false);
        }
    }
