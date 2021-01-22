    [Serializable]
    public sealed class DebugBreakAttribute : PostSharp.Laos.OnMethodBoundaryAspect
    {
    	public DebugBreakAttribute() {}
    	public DebugBreakAttribute(string category) {}
    	public string Category { get { return "DebugBreak"; } }
    
    	public override void OnEntry(PostSharp.Laos.MethodExecutionEventArgs eventArgs)
    	{
    		base.OnEntry(eventArgs);
    		// debugger will break here. Press F10 to continue to the "real" method
    		System.Diagnostics.Debugger.Break();
    	}
    }
