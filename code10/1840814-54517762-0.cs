    public class TrainData
        {
            [LoadColumn(0)]
            public string StationDepart { get; set; }
            [LoadColumn(1)]
            public string StationArrival { get; set; }
            [LoadColumn(2)]
            public string Day { get; set; }
            [LoadColumn(3)]
            public string Train { get; set; }
            [LoadColumn(4)]
            public string WeatherText { get; set; }
            [LoadColumn(5)]
            public float Temperature { get; set; }
            [LoadColumn(6)]
            public float Humidity { get; set; }
            [LoadColumn(7)]
            public bool HasPrecipitation { get; set; }
            [LoadColumn(8)]
            public string PrecipitationType { get; set; }
            [LoadColumn(9)]
            public float Time { get; set; }
            [LoadColumn(10)]
            public float Delay { get; set; }
        }
