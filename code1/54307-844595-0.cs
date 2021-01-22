    namespace Scratch
    {
    	public static class Util
    	{
    		public static IEnumerable<int> GetNumbers(int upto)
    		{
    			int i = 0;
    			while (i++<upto) yield return i;
    		}
    	}
    }
