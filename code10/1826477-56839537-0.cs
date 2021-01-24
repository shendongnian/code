    public class Phone : AuditBase 
    {
        ...other props...
        
        [AuditRuleset(AuditRule.PhoneNumber)]
        public string Number { get; set; }
    }
