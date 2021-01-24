	public static class SignFormatter
	{
		private static char SignHorizontalSide = '─';
		
		private static char SignTopLeft = (char)9486; //"┎"
		private static char SignTopRight = (char)9490; //"┒"
		private static char SignBottomLeft = (char)9492; //"└"
		private static char SignBottomRight = (char)9496; //"┘"
		private static char SignVerticalSide = (char)124; //"|"
		
		public static string FormatAsSign(string input, int length)
		{
			//Needed to adjust for end pipes
			length -= 2;
			
			StringBuilder sb = new StringBuilder();
            //calculates the padding needed to center the string in the sign
			int spaces = length - input.Length;
			int padLeft = spaces / 2 + input.Length;
			
            //Makes the sign with the centered text
			sb.AppendLine($"{SignTopLeft}{new String(SignHorizontalSide, length)}{SignTopRight}");
			sb.AppendLine($"{SignVerticalSide}{input.PadLeft(padLeft).PadRight(length)}{SignVerticalSide}");
			sb.AppendLine($"{SignBottomLeft}{new String(SignHorizontalSide, length)}{SignBottomRight}");
			
			return sb.ToString();
		}	
	}
