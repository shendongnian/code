	using System;
	using BenchmarkDotNet.Attributes;
	namespace BenchmarkFun
	{
		public class StringSubstringVsRemove
		{
			public readonly string SampleString = " My name is Daffy Duck.";
			[Benchmark]
			public string StringSubstring() => SampleString.Substring(1);
			[Benchmark]
			public string StringRemove() => SampleString.Remove(0, 1);
			public void AssertValidate()
			{
				string subsRes = StringSubstring();
				string remvRes = StringRemove();
				if (subsRes == null
					|| subsRes.Length != SampleString.Length - 1
					|| subsRes != remvRes) {
					throw new Exception("INVALID TEST!");
				}
			}
		}
	}
