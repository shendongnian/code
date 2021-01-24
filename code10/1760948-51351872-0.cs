    public class C1{
        public string p1 {get; set; }
        public string p2 {get; set; }
        public List<StatusChoices> ChoiceList { get; set; }
        ...
        public string FillList(string v1, int v2, bool v3){
    
            if(ChoiceList == null)
            {
                this.ChoiceList = new List<StatusChoices>();
            }
    
            var newItem = new StatusChoices {val1 = v1, val2 = v2, val3 = v3};
            this.ChoiceList.Add(newItem);
    
            return newItem.val1;
        }
    }
