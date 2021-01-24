    using CsAss;
    public class ObjectClicker : IClickHandler
    {
        CsAss _csass;
        public ObjectClicker(CsAss csass)
        {
            _csass = csass;
        }
        public void ClickObject()
        {
            _csass.clickObject();
        }
    }
