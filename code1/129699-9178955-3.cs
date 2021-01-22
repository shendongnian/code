    public interface I
    {
        event EventHandler SomethingHappened;
    }
    public class C : I
    {
        public void OnSomethingHappened()
        {
            // Same problem as above
            SomethingHappened(this, EventArgs.Empty);
        }
        
        event EventHandler I.SomethingHappened;
    }
