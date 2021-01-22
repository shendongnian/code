    public class MyList2 : Collection<object>, IDisplayable
    {
        public void GetControls()
        {
            foreach (IDisplayable displayable in this.OfType<IDisplayable>())
            {
                displayable.GetControl();
            }
        }
    }
