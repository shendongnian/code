    using System;
    using System.Text;
    public class Program {
           public static void Main(string[] args) {
                 StringBuilder sb = new StringBuilder();
                 int[] array = new Int[] { 51, 62, 23, 44 };
                 int combine = 0;
                 foreach(int single in array) {
                        string oneNum = single.ToString();
                        sb.Append(oneNum);
                 }
                 string final = sb.ToString();
                 combine = Convert.ToInt32(final);
           }
    }
