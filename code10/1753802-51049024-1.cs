	/// <summary>
	/// Describes a 2D-point.
	/// </summary>
	[DataContract]
	[DebuggerDisplay("{DebugDisplayString,nq}")]
	public struct Point : IEquatable<Point>
	{
        /// Other code here
	   	internal string DebugDisplayString
	    {
		    get
		    {
			    return string.Concat(
				    this.X.ToString(), "  ",
				    this.Y.ToString()
			);
		}
	}
  	  
