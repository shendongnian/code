    public class CustomGUIElement    
    {
        public void PerformClick()
        {
            OnClick(EventArgs.Empty);
        }
        protected virtual void OnClick(EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }
    }
