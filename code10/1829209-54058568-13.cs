	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	namespace ConsoleApp7
	{
		class Program
		{
			static void Main(string[] args)
			{
				List<FlattenedRawData> flattenedRawData = new List<FlattenedRawData>()
				{
					new FlattenedRawData()
					{
						EffectiveTIN = "EffectiveTIN_01",
						 MeasureID ="EffectiveTIN_01_MeasureID_01" ,
						 PerformanceMetCount = 1 ,
						 Stratum = "EffectiveTIN_01_MeasureID_01_Stratum_01"
					},
					new FlattenedRawData()
					{
						EffectiveTIN = "EffectiveTIN_01",
						 MeasureID ="EffectiveTIN_01_MeasureID_01" ,
						 PerformanceMetCount =2 ,
						 Stratum = "EffectiveTIN_01_MeasureID_01_Stratum_02"
					},
					 new FlattenedRawData()
					{
						EffectiveTIN = "EffectiveTIN_01",
						 MeasureID ="EffectiveTIN_01_MeasureID_02" ,
						 PerformanceMetCount = 3 ,
						 Stratum = "EffectiveTIN_01_MeasureID_02_Stratum_03"
					},
					new FlattenedRawData()
					{
						EffectiveTIN = "EffectiveTIN_01",
						 MeasureID ="EffectiveTIN_01_MeasureID_02" ,
						 PerformanceMetCount =4 ,
						 Stratum = "EffectiveTIN_01_MeasureID_02_Stratum_04"
					},
					   new FlattenedRawData()
					{
						EffectiveTIN = "EffectiveTIN_02",
						 MeasureID ="EffectiveTIN_02_MeasureID_03" ,
						 PerformanceMetCount = 5 ,
						 Stratum = "EffectiveTIN_02_MeasureID_03_Stratum_05"
					},
				};
				List<MeasurementSet__NoStrata> result_NoStrata = flattenedRawData.GroupBy(records => records.EffectiveTIN)
						.Select(y => new MeasurementSet__NoStrata
						{
							testTIN = y.Key,
							measurements = y.Select(i =>
									new Measurement_NoStrata()
									{
										measureId = i.MeasureID,
										value = new QualityMeasureValue_NoStrata
										{
											IsEndToEndReported = true,
											PerformanceMet = i.PerformanceMetCount
										}
									})
							.ToList()
						})
				.ToList();
				string requestJson1 = Newtonsoft.Json.JsonConvert.SerializeObject(result_NoStrata[0]);
				File.WriteAllText("output1.json", requestJson1);
				string requestJson2 = Newtonsoft.Json.JsonConvert.SerializeObject(result_NoStrata);
				File.WriteAllText("output2.json", requestJson2);
				List<MeasurementSet__MultiStrata> resul_MultiStrata = flattenedRawData.GroupBy(groupBy1 => groupBy1.EffectiveTIN)
					   .Select(level1 => new MeasurementSet__MultiStrata
					   {
						   testTIN = level1.Key,
						   measurements = level1.GroupBy(groupBy2 => groupBy2.MeasureID).Select(level2 =>
								  new Measurement_MultiStrata()
								  {
									  measureId = level2.Key,
									  value = new QualityMeasureValue_MultiStrata()
									  {
										  strata = level2.Select(level3 => new Strata
										  {
											  IsEndToEndReported = true,
											  PerformanceMet = level3.PerformanceMetCount
										  }).ToList(),
									  }
								  }).ToList()
					   }).ToList();
				string requestJson3 = Newtonsoft.Json.JsonConvert.SerializeObject(resul_MultiStrata[0]);
				File.WriteAllText("output3.json", requestJson3);
				string requestJson4 = Newtonsoft.Json.JsonConvert.SerializeObject(resul_MultiStrata);
				File.WriteAllText("output4.json", requestJson4);
			}
		}
		public class FlattenedRawData
		{
			public string EffectiveTIN { get; set; }
			public string MeasureID { get; set; }
			public int PerformanceMetCount { get; set; }
			public string Stratum { get; set; }
		}
		public class Measurement_NoStrata
		{
			public string measureId { get; set; }
			public QualityMeasureValue_NoStrata value { get; set; }
		}
		public class Measurement_MultiStrata
		{
			public string measureId { get; set; }
			public QualityMeasureValue_MultiStrata value { get; set; }
		}
		public class QualityMeasureValue_NoStrata
		{
			public bool IsEndToEndReported { get; set; }
			public int PerformanceMet { get; set; }
		}
		public class QualityMeasureValue_MultiStrata
		{
			public List<Strata> strata = new List<Strata>();
		}
		public class Strata
		{
			public bool IsEndToEndReported { get; set; }
			public int PerformanceMet { get; set; }
		}
		public class MeasurementSet__NoStrata
		{
			public string testTIN { get; set; }
			public List<Measurement_NoStrata> measurements { get; set; }
		}
		public class MeasurementSet__MultiStrata
		{
			public string category { get; set; }
			public string testTIN { get; set; }
			public List<Measurement_MultiStrata> measurements { get; set; }
		}
	}
