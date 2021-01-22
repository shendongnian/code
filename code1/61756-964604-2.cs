    public class MyUserControlDesigner : ControlDesigner
    {
        
        private DesignerActionListCollection _actionLists;
        public override System.ComponentModel.Design.DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actionLists == null)
                {
                    _actionLists = new DesignerActionListCollection();
                    _actionLists.Add(new MyUserControlActionList(this));
                }
                return _actionLists;
            }
        }
    }
