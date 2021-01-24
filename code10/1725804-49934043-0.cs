     public class ClassA
     {
        public string Name{get;set;}
        public event EventHandler FilterButtonClicked;
        private void OnFilterButtonClick()
        {
           FilterButtonClicked?.Invoke(this, EventArgs.Empty);
        }
     }
