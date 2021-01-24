        using (var serdeProvider = new AvroSerdeProvider(avroConfig))
        using (var producer = new Producer<string, GenericRecord>(producerConfig, serdeProvider.GetSerializerGenerator<string>(), serdeProvider.GetSerializerGenerator<GenericRecord>()))
        {
            Console.WriteLine($"{producer.Name} producing on {topicName}. Enter user names, q to exit.");
    
            int i = 0;
            string text;
            while ((text = Console.ReadLine()) != "q")
            {
                var record = new GenericRecord(s);
                record.Add("name", text);
                record.Add("favorite_number", i++);
                record.Add("favorite_color", "blue");
    
                producer
                    .ProduceAsync(topicName, new Message<string, GenericRecord> { Key = text, Value = record })
                    .ContinueWith(task => task.IsFaulted
                        ? $"error producing message: {task.Exception.Message}"
                        : $"produced to: {task.Result.TopicPartitionOffset}");
            }
        }
    
        cts.Cancel();
    }
