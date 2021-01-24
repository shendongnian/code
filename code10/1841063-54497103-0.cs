using System;
using System.Collections.Generic;
namespace WindowsFormsApp1
{
	static class ListShuffle
	{
		private static Random rand = new Random();
		public static void Shuffle<T>(this IList<T> list)
		{
			int n = list.Count - 1;
			while (n > 1)
			{
				int k = rand.Next(n);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
				n--;
			}
		}
	}
}
Then, in your Form1.cs, take out the code in the constructor related to the answer buttons and use:
private void Form1_Load(object sender, EventArgs e)
{
	var buttons = new List<Button> { Answer1Btn, Answer2Btn, Answer3Btn };
	buttons.Shuffle();
	buttons[0].Text = "A";
	buttons[1].Text = "B";
	buttons[2].Text = "C";
}
and see how the letters ABC are randomly assigned each time the form is loaded.
After confirming that it works for that, adjust it to be:
buttons[0].Text = GetAnswer();
buttons[1].Text = GetFalse1();
buttons[2].Text = GetFalse2();
(I have to guess that it will work with the way you are checking the answer.)
