    public class MyList2 : Collection<object>, IDisplayable
    {
        public void GetControl()
        {
            foreach (IDisplayable displayable in this.OfType<IDisplayable>())
            {
                displayable.GetControl();
            }
        }
    }
