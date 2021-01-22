    public class SampleClass2b
    {
    	public Int16 a;
    	[DynamicCastHelperSizeAttribute(5)]
    	public byte[] ba; //{ get; set; }
    	[DynamicCastHelperSizeAttribute(4)]
    	public byte[] bb; //{ get; set; }
    	public Int32 c;
    }
    byte[] data2b = new byte[] { 0, 17, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0, 0, 0, 10 };
    SampleClass2b clas2b = new SampleClass2b();
    CDynamicCastHelper.CastIntoFields(clas2b, data2b, CastOptions.ReverseDWord | CastOptions.ReverseWord);
