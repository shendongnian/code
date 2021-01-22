    public class MySmartObject
    {
        public string Name { get; set; }
        public int Number { get; set; }
        private int clean_hashcode { get; set; }
        public bool IsDirty { get { return !(this.clean_hashcode == this.GetHashCode()); } }
        public MySmartObject()
        {
            this.Name = "";
            this.Number = -1;
            MakeMeClean();
            
        }
        public MySmartObject(string name, int number)
        {
            this.Name = name;
            this.Number = number;
            MakeMeClean();
        }
        public void MakeMeClean()
        {
            this.clean_hashcode = this.Name.GetHashCode() ^ this.Number.GetHashCode();
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Number.GetHashCode();
        }
    }
