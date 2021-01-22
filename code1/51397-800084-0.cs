    class Element : IComparable<Element>
    {
        public int Priority { get; set; }
        public string Description { get; set; }
    
        public int CompareTo(Element other)
        {
            if (Priority.CompareTo(other.Priority) == 0)
            {
                return Description.CompareTo(other.Description);
            } else {
                return Priority.CompareTo(other.Priority);
            }
        }
    }
