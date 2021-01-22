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
			public void AssertTestIsValid()
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
		class Program
		{
			static void Main()
			{
				// let's make sure test results are really equal / valid
				new StringSubstringVsRemove().AssertTestIsValid();
				var summary = BenchmarkRunner.Run<StringSubstringVsRemove>();
			}
		}
	}
