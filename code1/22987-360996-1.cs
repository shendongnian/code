    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using MiscUtil.Linq;
    using MiscUtil.Linq.Extensions;
    static class Program
    {
    
        static void Main()
        {
            // prepare a query that is capable of parsing
            // the input file into the expected format
            string path = "foo.txt";
            var qry = from line in ReadLines(path)
                      let arr = line.Split(',')
                      select new
                      {
                          Name = arr[0].Trim(),
                          Male = arr[1].Trim() == "male",
                          Birth = int.Parse(arr[2].Trim()),
                          M1 = int.Parse(arr[3].Trim())
                          // etc
                      };
    
            // get a "data producer" to start the query process
            var producer = CreateProducer(qry);
            // prepare the overall average
            var avg = producer.Average(row => row.M1);
    
            // prepare the gender averages
            var avgMale = producer.Where(row => row.Male)
                        .Average(row => row.M1);    
            var avgFemale = producer.Where(row => !row.Male)
                        .Average(row => row.M1);
            
            // run the query; until now *nothing has happened* - we haven't
            // even opened the file    
            producer.ProduceAndEnd(qry);
            // show the results
            Console.WriteLine(avg.Value);
            Console.WriteLine(avgMale.Value);
            Console.WriteLine(avgFemale.Value);
        }
        // helper method to get a DataProducer<T> from an IEnumerable<T>, for
        // use with the anonymous type
        static DataProducer<T> CreateProducer<T>(IEnumerable<T> data)
        {
            return new DataProducer<T>();
        }
        // this is just a lazy line-by-line file reader (iterator block)    
        static IEnumerable<string> ReadLines(string path)
        {
            using (var reader = File.OpenText(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    
    }
