     public class Program
    {
        public static void Main(string[] args)
        {
			var list = new []{1,2,3,4,5};
			
			var objects = new []{new Obj(),new Obj(),new Obj(),new Obj(),new Obj()};
			
			objects = objects.Select((x,i)=>{
				x.Int = list[i];
				
				return x;
			}).ToArray();
			
			foreach(var o in objects)
			{
				Console.WriteLine(o.Int);
			}
				
        }
        }
    
    public class Obj 
    {
    	public int Int {get;set;}
    }
