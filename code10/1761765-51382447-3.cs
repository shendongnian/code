    public class MyItem
    {
    	private byte deviceAddress { get; set; }
    	private byte register { get; set; }
    	private byte[] data { get; set; }
    }
    
    public list<MyItem> MyMatrix; // Composed by 16 elements
