    using CsAss;
    public class ObjectClicker : IClickHandler
    {
        CsAss _csass;
        pubic ObjectClicker(CsAss csass)
        {
            _csass = csass;
        }
        public void ClickObject()
        {
            _csass.clickObject();
        }
    }
