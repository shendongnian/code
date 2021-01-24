    class BaseTreeData
    {
        //Other stuff here
        //...
        public override string ToString()
        {
            return IsChecked.ToString();
        }
    }
    class TreeData : BaseTreeData
    {
        //Other stuff here
        //...
        public override string ToString()
        {
            var format = "{0} {1} {2}";
            var stringRepresentation = string.Format(format, ID, Name, base.ToString());
            return stringRepresentation;
        }
    }
