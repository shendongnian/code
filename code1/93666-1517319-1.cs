    public class AddFindingsState : IApplicationState
    {
        frmMain _mForm;
        public AddFindingsState(frmMain mForm)
        {
            this._mForm = mForm;
        }
                
        public void ClickOnAddFindings()
        {            
        }
        public void ClickOnViewReport()
        {
            // Set the State
            _mForm.SetState(_mForm.GetViewTheReportState());
        }
    }
