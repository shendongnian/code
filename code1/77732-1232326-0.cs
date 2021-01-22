    public partial class PolicyErrorEndingDates
        {
            public int ID_P {get;set;}
            public DateTime DT_S_E {get;set;}
            public DateTime DT_SC_E {get;set;}
    
            public List<PolicyErrorDescr> Errors {get;set;}
            public PolicyErrorEndingDates()
            {
                Errors = new List<PolicyErrorDescr>()
            }
        }
