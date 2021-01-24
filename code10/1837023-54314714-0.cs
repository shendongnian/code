    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication98
    {
        class Program
        {
            static void Main(string[] args)
            {
                Response response = new Response() {
                    Makes = new List<Make>() {
                        new Make() { 
                            Name = "AAA", Agents = new List<Agent>() { 
                                new Agent() { 
                                    Id = 123, Name = "SSS", Offers = new List<Offer>() { 
                                        new Offer() {  
                                            Id = 100, Models = new List<Model>() { 
                                                new Model() { Name = "TTT", Price = new Price() { Total = 1.0M, Vat = 2.0M}},
                                                new Model() { Name = "UUU", Price = new Price() { Total = 2.0M, Vat = 3.0M}},
                                            },
                                        },
                                        new Offer() {  
                                            Id = 200, Models = new List<Model>() { 
                                                new Model() { Name = "TTT", Price = new Price() { Total = 1.0M, Vat = 2.0M}},
                                                new Model() { Name = "UUU", Price = new Price() { Total = 2.0M, Vat = 3.0M}}
                                            }
                                        }
                                    }
                                },
                                new Agent() { 
                                    Id = 456, Name = "SST", Offers = new List<Offer>() { 
                                        new Offer() {  
                                            Id = 100, Models = new List<Model>() { 
                                                new Model() { Name = "TTT", Price = new Price() { Total = 1.0M, Vat = 2.0M}},
                                                new Model() { Name = "UUU", Price = new Price() { Total = 2.0M, Vat = 3.0M}},
                                            },
                                        },
                                        new Offer() {  
                                            Id = 200, Models = new List<Model>() { 
                                                new Model() { Name = "TTT", Price = new Price() { Total = 1.0M, Vat = 2.0M}},
                                                new Model() { Name = "UUU", Price = new Price() { Total = 2.0M, Vat = 3.0M}}
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new Make() { 
                            Name = "AAB", Agents = new List<Agent>() { 
                                new Agent() { 
                                    Id = 123, Name = "SSS", Offers = new List<Offer>() { 
                                        new Offer() {  
                                            Id = 100, Models = new List<Model>() { 
                                                new Model() { Name = "TTT", Price = new Price() { Total = 1.0M, Vat = 2.0M}},
                                                new Model() { Name = "UUU", Price = new Price() { Total = 2.0M, Vat = 3.0M}},
                                            },
                                        },
                                        new Offer() {  
                                            Id = 200, Models = new List<Model>() { 
                                                new Model() { Name = "TTT", Price = new Price() { Total = 1.0M, Vat = 2.0M}},
                                                new Model() { Name = "UUU", Price = new Price() { Total = 2.0M, Vat = 3.0M}}
                                            }
                                        }
                                    }
                                },
                                new Agent() { 
                                    Id = 456, Name = "SST", Offers = new List<Offer>() { 
                                        new Offer() {  
                                            Id = 100, Models = new List<Model>() { 
                                                new Model() { Name = "TTT", Price = new Price() { Total = 1.0M, Vat = 2.0M}},
                                                new Model() { Name = "UUU", Price = new Price() { Total = 2.0M, Vat = 3.0M}},
                                            },
                                        },
                                        new Offer() {  
                                            Id = 200, Models = new List<Model>() { 
                                                new Model() { Name = "TTT", Price = new Price() { Total = 1.0M, Vat = 2.0M}},
                                                new Model() { Name = "UUU", Price = new Price() { Total = 2.0M, Vat = 3.0M}}
                                            }
                                        }
                                    }
                                }
                            }
                        }
                   }
                };
                DataTable dt = new DataTable();
                dt.Columns.Add("Make Name", typeof(string));
                dt.Columns.Add("Agent ID", typeof(int));
                dt.Columns.Add("Agent Name", typeof(string));
                dt.Columns.Add("Offer ID", typeof(int));
                dt.Columns.Add("Model Name", typeof(string));
                dt.Columns.Add("Total", typeof(decimal));
                dt.Columns.Add("Vat", typeof(decimal));
                foreach (Make make in response.Makes)
                {
                    string makeName = make.Name;
                    foreach (Agent agent in make.Agents)
                    {
                        int agentID = agent.Id;
                        string agentName = agent.Name;
                        foreach (Offer offer in agent.Offers)
                        {
                            int offerID = offer.Id;
                            foreach (Model model in offer.Models)
                            {
                                string modelName = model.Name;
                                decimal vat = model.Price.Vat;
                                decimal total = model.Price.Total;
                                dt.Rows.Add(new object[] {
                                    makeName,
                                    agentID,
                                    agentName,
                                    offerID,
                                    modelName,
                                    vat,
                                    total
                                });
                            }
                        }
                    }
                }
                dt = dt.AsEnumerable().OrderBy(x => x.Field<decimal>("Total")).CopyToDataTable();
            }
        }
        public class Response
        {
            public List<Make> Makes { get; set; }
            public Response()
            {
                this.Makes = new List<Make>();
            }
        }
        public class Make
        {
            public string Name { get; set; }
            public List<Agent> Agents { get; set; }
            public Make()
            {
                this.Agents = new List<Agent>();
            }
        }
        public class Agent
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Offer> Offers { get; set; }
            public Agent()
            {
                this.Offers = new List<Offer>();
            }
        }
        public class Offer
        {
            public int Id { get; set; }
            public List<Model> Models { get; set; }
            public Offer()
            {
                this.Models = new List<Model>();
            }
        }
        public class Model
        {
            public string Name { get; set; }
            public Price Price { get; set; }
            public Model()
            {
                this.Price = new Price();
            }
        }
        public class Price
        {
            public decimal Total { get; set; }
            public decimal Vat { get; set; }
        }
    }
