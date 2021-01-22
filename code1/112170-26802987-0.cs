    public override String Message {
        get {  
            return base.Message + String.Format(", HttpStatusCode={0}, RequestId='{1}'", 
                        httpStatusCode, 
                        RequestId);
        }
    }
