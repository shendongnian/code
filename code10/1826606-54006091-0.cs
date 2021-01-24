    using Confluent.Kafka;
    using System;
    using System.Collections.Generic;
    
    namespace deleteKafkaTopic
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine($"librdkafka Version: {Library.VersionString} ({Library.Version:X})");
                Console.WriteLine($"Debug Contexts: {string.Join(", ", Library.DebugContexts)}");
    
                IEnumerable<string> topicList = new List<string>() { "test-topic4" };
                deleteTopics("192.168.64.49:9092", topicList);
            }
            static void deleteTopics(string brokerList, IEnumerable<string> topicNameList)
            {
                using (var adminClient = new AdminClient(new AdminClientConfig { BootstrapServers = brokerList }))
                {
                    adminClient.DeleteTopicsAsync(topicNameList, null);
                }
            }
        }
    }
