	public class Crate:IDensity
	{
	    //Dummy numbers
	    public int getWeight()=>55;
	    public int getVolume()=>100;
	}
	public class C {
	    public void M() {
	        IDensity box=new Cake();
	        Console.WriteLine(box.Density);
	    }
	}
