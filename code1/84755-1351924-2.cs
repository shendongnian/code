    public class MyList : Collection<IDisplayable>, IDisplayable
    {
        public void GetControl()
        {
            foreach (IDisplayable displayable in this)
            {
                displayable.GetControl();
            }
        }
    }
