    public class RollingFileCustomAppender: RollingFileAppender
    {
	    public Int32 NewNode { get; set; }
	    protected override void AdjustFileBeforeAppend()
        {
             // Do something with this.NewNode
        }
 
        // ...
    }
