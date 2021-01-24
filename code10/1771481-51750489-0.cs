    public interface IMyObject<out T> where T: IMyParaInterface {}
	public class MyObject<T> : IMyObject<T> where T: IMyParaInterface {}
	
	
	public static void Print(IMyObject<IMyParaInterface> parameter)  {}
