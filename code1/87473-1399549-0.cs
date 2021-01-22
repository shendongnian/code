    public interface IReadOnly
    {
    	String GetId();
    }
    
    public interface ICanReadAndWrite : IReadOnly
    {
    	String SetId();
    }
