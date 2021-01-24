	public partial class FormMain : Form
    {
        public FormMain()
        {
            myCboFooList.SelectedValueChanged += OnMyCboFooList_SelectedValueChanged;
            myCboFooList.EvSelectedValueChanged = OnMyCboFooList_SelectedValueChanged;
        }
        private void OnMyCboFooList_SelectedValueChanged(object sender, EventArgs e)
        {
            // do stuff 
        }
    }
	
