public class NavigateErrorArgs : EventArgs
{
    public object StatusCode { get; set; }
    public NavigateErrorArgs()
            : base()
    { }
    public NavigateErrorArgs(object statusCode)
            : base()
    {
       this.StatusCode = statusCode;
    }
}
