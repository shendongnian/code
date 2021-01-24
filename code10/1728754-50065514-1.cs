    public partial class Setting : Form
    {
        /* auto property */
        public List<string> List { get; internal set; }
        public Setting(List<string> listToModify)
        {
            this.List = listToModify;
        }
        
        private void ModifyList()
        {
            /* here, you modify this.List because you assigned MainForm.List1
            to this.List in the code above */ 
        }
    }
