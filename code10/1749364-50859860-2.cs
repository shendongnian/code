    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    namespace JsonDemo
    {
        public class Stock
        {
            public string Bin { get; set; }
            public string Article { get; set; }
            public int Quantity { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                string json = @"[{""Bin"":""MJ11906"",""Article"":""148400MU_"",""Quantity"":50},{""Bin"":""ME04307"",""Article"":""148400MU_"",""Quantity"":56},{""Bin"":""MD08301"",""Article"":""148400MU_"",""Quantity"":66},{""Bin"":""MG12303"",""Article"":""148400MU_"",""Quantity"":70},{""Bin"":""ME04402"",""Article"":""148400MU_"",""Quantity"":72},{""Bin"":""ME12402"",""Article"":""148400MU_"",""Quantity"":72}]";
                var stocks = JsonConvert.DeserializeObject<IEnumerable<Stock>>(json);
                var stocks2 = JsonConvert.DeserializeObject<IList<Stock>>(json);
                var stocks3 = JsonConvert.DeserializeObject<List<Stock>>(json);
                var stocks4 = JsonConvert.DeserializeObject<Stock[]>(json);
                string json2 = JsonConvert.SerializeObject(stocks);
                stocks = JsonConvert.DeserializeObject<IEnumerable<Stock>>(json);
                stocks2 = JsonConvert.DeserializeObject<IList<Stock>>(json);
                stocks3 = JsonConvert.DeserializeObject<List<Stock>>(json);
                stocks4 = JsonConvert.DeserializeObject<Stock[]>(json);
                Console.WriteLine("Press any key to continue");
                Console.Read();
            }
        }
    }
