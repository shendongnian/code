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
                        EffectiveTIN = "a",
                         MeasureID ="b" ,
                         PerformanceMetCount = 1 ,
                         Stratum = "c"
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
    
    
                List<MeasurementSet__MultiStrata> resul_MultiStrata = flattenedRawData.GroupBy(records => records.EffectiveTIN)
                       .Select(y => new MeasurementSet__MultiStrata
                       {
                           testTIN = y.Key,
                           measurements = y.Select(i =>
                                   new Measurement_MultiStrata()
                                   {
                                       measureId = i.MeasureID,
                                       value = new QualityMeasureValue_MultiStrata
                                       {
                                           strata = new List<Strata>() { new Strata() { IsEndToEndReported = true, PerformanceMet = i.PerformanceMetCount } }
                                       }
                                   }).ToList()
                       })
               .ToList();
    
    
                string requestJson2 = Newtonsoft.Json.JsonConvert.SerializeObject(resul_MultiStrata[0]);
    
                File.WriteAllText("output2.json", requestJson2);
    
         
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
