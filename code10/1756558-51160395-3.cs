    public class ConditionModle
    {
        public bool setb1 { get; set; }
        public bool setb2 { get; set; }
        public bool setb3 { get; set; }
        public bool setb4 { get; set; }
        public bool setb5 { get; set; }
        ....
        public bool Condition1()
        {
            return !this.setb1 && !this.setb2 && !this.setb4;
        }
    }
 
    if (model.Condition1())
        MyFunction(model);
