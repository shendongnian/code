    public class MyControlDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionList;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionList == null)
                    actionList = new DesignerActionListCollection(new[] {
                        new MyControlActionList(this) });
                return actionList;
            }
        }
    }
