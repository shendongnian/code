    public string FillList(string v1, int v2, bool v3){
        this.ChoiceList = new List<StatusChoices> {
         new StatusChoices { val1 = v1, val2 = v2, val3 = v3, } };
        return this.ChoiceList[0].val1;
    }
