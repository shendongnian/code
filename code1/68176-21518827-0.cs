    public class BtoSelectedListItem : SelectListItem
    {
        public int IntValue
        {
            get { return string.IsNullOrEmpty(Value) ? 0 : int.Parse(Value); }
            set { Value = value.ToString(); }
        }
    }
