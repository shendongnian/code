    public class MyList : Collection<IDisplayable>, IDisplayable
    {
        public void GetControls()
        {
            foreach (IDisplayable displayable in this)
            {
                displayable.GetControl();
            }
        }
    }
