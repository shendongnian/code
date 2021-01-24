    public class Button2 : Button
    {
        public EventHandler Clicked2
        {
            get { return this.Clicked; }
            set
            {
                this.Clicked += value;
            }
        }
    }
