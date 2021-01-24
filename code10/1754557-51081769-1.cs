        namespace ScoreDuizenden
        {
            public partial class NaamSpelers : Form
            {
                private string cbAntalSpelers = string.Empty; // class level field to store combo value
                public NaamSpelers(string cboValue)  // combo value need to be passed to this form whenever a new instance is created
                {
                    InitializeComponent();
                    this.cbAntalSpelers = cboValue;
                }
    
                ....
            }
        }
