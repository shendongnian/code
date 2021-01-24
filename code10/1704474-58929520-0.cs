	public class Range
	{
		public Range(int num)
		{
			Left = Right = num;
		}
		
		public int Left { get; set; }
		
		public int Right { get; set; }
	
		public bool IsAdjecentRight(int num)
		{
			return num == Right+1;
		}
	
		public bool TryAddRight(int num)
		{
			if (!IsAdjecentRight(num)) return false;
			Right = num;
			return true;
		}
		
		public override string ToString()
		{
			if (Left == Right) return $"{Left}";
			if (Left == Right - 1) return $"{Left},{Right}";
			return $"{Left}-{Right}";
		}
	}
