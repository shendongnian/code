    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication13
    {
    class Program
    {
        static void Main(string[] args)
        {
            var _service = new Service();
            Func<CostStore, bool> condition = s => s.DirectorateId == 10;
            Func<CostStore, decimal> projection = GetProjection();
            var c = _service.List().Where(condition).Select(projection);
        }
        private static Func<CostStore, decimal> GetProjection()
        {
            return c => c.NewCar;
        }
        class Service
        {
            public IEnumerable<CostStore> List()
            {
                return new List<CostStore>();
            }
        }
        public class CostStore
        {
            public int DirectorateId { get; set; }
            public decimal NewCar { get; set; }
        }
    }
    }
