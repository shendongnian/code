    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApp1
    {
    public static class GetSum
    {
        public static double SumOfValues(this StudyAreasClass item)
        {
            return item.Value1 + item.Value2 + item.Value3 + item.Value4;
        }
    }
    public class StudyAreasClass
    {
        public string Plant { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Value3 { get; set; }
        public double Value4 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<StudyAreasClass> Production = new List<StudyAreasClass>();
            Production.Add(new StudyAreasClass() { Plant = "Plant A", Value1 = 94.4, Value2 = 97.2, Value3 = 71.9, Value4 = 12.8 });
            Production.Add(new StudyAreasClass() { Plant = "Plant B", Value1 = 84.1, Value2 = 95.2, Value3 = 64.8, Value4 = 92.5 });
            Production.Add(new StudyAreasClass() { Plant = "Plant C", Value1 = 43.1, Value2 = 66.3, Value3 = 92.7, Value4 = 84.0 });
            Production.Add(new StudyAreasClass() { Plant = "Plant D", Value1 = 72.6, Value2 = 51.2, Value3 = 87.9, Value4 = 68.1 });
            List<StudyAreasClass> orderedProduction = Production.OrderBy(row => row.SumOfValues()).ToList<StudyAreasClass>();
            foreach(StudyAreasClass item in orderedProduction)
            {
                Console.WriteLine($" {item.Plant} {item.SumOfValues()}");
            }
            Console.ReadKey();
        }
    }
}
