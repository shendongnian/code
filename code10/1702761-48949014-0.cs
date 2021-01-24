    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication25
    {
        class Program
        {
           static void Main(string[] args)
            {
                List<EZA> ezaCollection = new List<EZA>() {
                    new EZA() {
                        someDate = "2018-03-24",
                        PZA = new List < PZA > () {
                            new PZA {
                                name = "inter_1"
                            },
                            new PZA {
                                name = "inter_2"
                            },
                        }
                    },
                    new EZA() {
                        someDate = "2018-04-24",
                        PZA = new List <PZA> () {
                            new PZA {
                                name = "inter_2"
                            },
                            new PZA {
                                name = "inter_3"
                            },
                        }
                    }
                };
                var names = ezaCollection.Select(eza => eza.PZA.Select(y => new { date = eza.someDate, PZA = eza.PZA, pza = y, Name = y.name })).SelectMany(x => x).ToList();
                var groups = names.OrderByDescending(x => x.date).GroupBy(x => x.Name).ToList();
                foreach (var group in groups)
                {
                    foreach (var item in group.Skip(1))  //skip latest
                    {
                        item.PZA.Remove(item.pza);
                    }
                }
            }
        }
        public class EZA
        {
            public string name { get; set;}
            public string someDate { get; set; }
            public List<PZA> PZA { get; set;}
        }
        public class PZA
        {
            public string name { get; set; }
        }
    }
