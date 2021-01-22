    // This interface allows the caller to
    // obtain a container's subitems.
    public interface IEnumerator
    {
       bool MoveNext (); // Advance the internal position of the cursor.
       object Current { get;} // Get the current item (read-only property).
       void Reset (); // Reset the cursor before the first member.
    }
