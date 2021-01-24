    public class MyMenuItemOnMenuItemClickListener : Java.Lang.Object, IMenuItemOnMenuItemClickListener
    {
        private MainActivity mContext;
        public Func<string, Task<string>> EvaluateJavascript { get; set; }
        private ActionMode actionMode;
    
        public MyMenuItemOnMenuItemClickListener(MainActivity activity,ActionMode mode)
        {
            this.mContext = activity;
            this.actionMode=mode;
        }
    
        public bool OnMenuItemClick(IMenuItem item)
        {
            //Web is a static class declared elsewhere
            Web.CopyToMainNotes();
            //close menu if menu item is clicked
            if(actionMode!=null){
            actionMode.finish()
            }
            return true;
        }
    }
