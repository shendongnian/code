    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using SnakeCase.JsonNet;
    
    namespace Anonymous.Public.Namespace
    {
        public class Person
        {
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
            public bool EatsMeat { get; set; }
            public decimal YearlyHouseholdIncome { get; set; }
    
            public List<Car> CarList { get; set; }
        }
    
        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
        }
        public class NoOpNamingStrategy : NamingStrategy
        {
            public NoOpNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames)
            {
                base.ProcessDictionaryKeys = processDictionaryKeys;
                base.OverrideSpecifiedNames = overrideSpecifiedNames;
            }
    
            public NoOpNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames, bool processExtensionDataNames) : this(processDictionaryKeys, overrideSpecifiedNames)
            {
                base.ProcessExtensionDataNames = processExtensionDataNames;
            }
    
            public NoOpNamingStrategy()
            {
            }
    
            protected override string ResolvePropertyName(string name)
            {
                return name;
            }
        }
    
        [TestClass]
        public class SerializationTest
        {
            public static Person p { get; set; } = new Person
            {
                Name = "Foo Bar",
                DateOfBirth = new DateTime(1970, 01, 01),
                EatsMeat = true,
                YearlyHouseholdIncome = 47333M,
                CarList = new List<Car>
                {
                    new Car
                    {
                        Make = "Honda",
                        Model = "Civic",
                        Year = 2019
                    }
                }
            };
    
            public static IContractResolver Default { get; set; } = new DefaultContractResolver();
    
            public static IContractResolver NoOp { get; set; } = new DefaultContractResolver
            {
                NamingStrategy = new NoOpNamingStrategy()
            };
    
            public static IContractResolver SnakeCase { get; set; } = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
    
            public static IContractResolver ThirdParty { get; set; } = new SnakeCaseContractResolver();
    
            public const int ITERATIONS = 1000;
    
            [TestMethod]
            public void TestSnakeCase()
            {
                var sw = new Stopwatch();
                sw.Start();
                for (var i = 0; i < ITERATIONS; i++)
                {
                    var str = JsonConvert.SerializeObject(p, new JsonSerializerSettings
                    {
                        ContractResolver = SnakeCase
                    });
                }
    
                sw.Stop();
                var elapsed = sw.ElapsedMilliseconds;
                Debug.WriteLine($"Time elapsed {elapsed} milliseconds");
            }
    
            [TestMethod]
            public void TestNoResolver()
            {
                var sw = new Stopwatch();
                sw.Start();
                for (var i = 0; i < ITERATIONS; i++)
                {
                    var str = JsonConvert.SerializeObject(p);
                }
    
                sw.Stop();
                var elapsed = sw.ElapsedMilliseconds;
                Debug.WriteLine($"Time elapsed {elapsed} milliseconds");
            }
    
            [TestMethod]
            public void TestDefaultResolver()
            {
                var sw = new Stopwatch();
                sw.Start();
                for (var i = 0; i < ITERATIONS; i++)
                {
                    var str = JsonConvert.SerializeObject(p, new JsonSerializerSettings
                    {
                        ContractResolver = Default
                    });
                }
    
                sw.Stop();
                var elapsed = sw.ElapsedMilliseconds;
                Debug.WriteLine($"Time elapsed {elapsed} milliseconds");
            }
    
            [TestMethod]
            public void TestThirdPartySnakeResolver()
            {
                var sw = new Stopwatch();
                sw.Start();
                for (var i = 0; i < ITERATIONS; i++)
                {
                    var str = JsonConvert.SerializeObject(p, new JsonSerializerSettings
                    {
                        ContractResolver = ThirdParty
                    });
                }
    
                sw.Stop();
                var elapsed = sw.ElapsedMilliseconds;
                Debug.WriteLine($"Time elapsed {elapsed} milliseconds");
            }
    
            [TestMethod]
            public void TestNoOpResolver()
            {
                var sw = new Stopwatch();
                sw.Start();
                for (var i = 0; i < ITERATIONS; i++)
                {
                    var str = JsonConvert.SerializeObject(p, new JsonSerializerSettings
                    {
                        ContractResolver = NoOp
                    });
                }
    
                sw.Stop();
                var elapsed = sw.ElapsedMilliseconds;
                Debug.WriteLine($"Time elapsed {elapsed} milliseconds");
            }
        }
    }
