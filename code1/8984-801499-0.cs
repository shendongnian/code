    // usage:
    public class FullConditionUITypeEditor : UITypeEditor
    {
        // The immediate caller is required to have been granted the FullTrust permission.
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        public FullConditionUITypeEditor() { }
    }
