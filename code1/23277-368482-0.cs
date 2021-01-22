    using System;
    
    public interface IPublic
    {
    	void Public();
    }
    
    internal interface IInternal : IPublic
    {
    	void Internal();
    }
    
    public class Concrete : IInternal
    {
    	public void Internal() { }
    
    	public void Public() { }
    }
