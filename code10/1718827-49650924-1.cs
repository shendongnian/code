     public class Product : Observable
    {
        public int ProductId { get; set; }
        private bool isOn;
        public bool IsOn
        {
            get { return isOn; }
            set { isOn = value; Set(ref isOn, value, nameof(IsOn)); }
        }
    }
