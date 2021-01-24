    public override DesignerActionListCollection ActionLists
    {
        get
        {   
            var actionLists = new DesignerActionListCollection();
            actionLists.Add(new MyControlTasks(this.Component));
            return actionLists;
        }
    }
