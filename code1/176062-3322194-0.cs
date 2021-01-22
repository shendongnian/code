    public class MyBindingList<T> : BindingList<T>
    {
        public override string ToString()
        {
            if (this.Count == 0)
            {
                return "Empty BindingList";
            }
    
            return "BindingList of " + this[0].ToString();
        }
    }
