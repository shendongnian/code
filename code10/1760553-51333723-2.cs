    void Main()
    {
    	MyObj myObject = new MyObj();
    	Console.WriteLine(myObject.prop2.p2);  //2
    	foreach (var prop in typeof(MyObj).GetProperties())
    	{
    		var propObj = (MyObj.MyPropObj)prop.GetValue(myObject);
    		propObj.p1++;
    		propObj.p2++;
    		propObj.p3++;
    	}
    	Console.WriteLine(myObject.prop2.p2);  //3
    }
    
    class MyObj
    {
    	public class MyPropObj
    	{
    		public int p1 { get; set; }
    		public int p2 { get; set; }
    		public int p3 { get; set; }
    		public MyPropObj(int one, int two, int three)
    		{
    			p1 = one;
    			p2 = two;
    			p3 = three;
    		}
    	}
    	public MyPropObj prop1 { get; set; } = new MyPropObj(0, 1, 2);
    	public MyPropObj prop2 { get; set; } = new MyPropObj(0, 2, 4);
    	public MyPropObj prop3 { get; set; } = new MyPropObj(0, 4, 8);
    }
