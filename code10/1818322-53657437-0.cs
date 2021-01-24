        using (var serdeProvider = new AvroSerdeProvider(avroConfig))
                using (var producer = new Producer<string, MYClass>(producerConfig, 
          serdeProvider.GetSerializerGenerator<string>(), 
          serdeProvider.GetSerializerGenerator<MYClass>()))
                {
                    Console.WriteLine($"{producer.Name} producing on 
               {_appSettings.PullListKafka.Topic}.");  
    
                    producer.ProduceAsync(_appSettings.PullListKafka.Topic, new 
        Message<string, MYClass> { Key = Guid.NewGuid().ToString(), Value = MYClassObject})
                            .ContinueWith(task => task.IsFaulted
                                ? $"error producing message: {task.Exception.Message}"
                                : $"produced to: {task.Result.TopicPartitionOffset}");
                  
                }
