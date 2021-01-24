    using System;
    using System.Collections.Generic;
    public class Test
    {
	  public static void Main()
	  {
		 Dictionary<string, List<double> > map = new Dictionary<string, List<double> >();
		 List<double>listA =  new List<double>(new double[]{681,305,305,304,667,92.87,254.51,100.24});
		 map.Add("A", listA);
		 List<double>listB =  new List<double>(new double[]{460,682,702,683,443,89.17,273.83,102.19});
		 map.Add("B", listB);
		 List<double>listC = new List<double>(new double[]{593,395,413,418,564,71.13,17.67,83.79});
		 map.Add("C", listC);
		 List<double>testList = new List<double>(new double[]{593,395,413,418,564,71.13,17.67,83.79});
		 string ans = mostSimilarKey(testList, map);
		 Console.WriteLine("Most similar key is: "+ans);
	  }
	
	  static string mostSimilarKey(List<double>testList, Dictionary<string, List<double> > map) {
		double minDifference = Double.MaxValue;
		string ans = "";
		foreach (var pair in map) {
			double absoluteDifference = getAbsoluteDifference(testList, pair.Value);
			if (absoluteDifference < minDifference) {
				minDifference = absoluteDifference;
				ans = pair.Key;
			}
		}
		return ans;
	 }
	
	 static double getAbsoluteDifference(List<double>testList, List<double>list) {
		double absoluteDifference = 0.0;
		for (int i = 0; i < testList.Count; ++i) {
			absoluteDifference += Math.Abs(testList[i] - list[i]);
		}
		return absoluteDifference;
	  }
    }
