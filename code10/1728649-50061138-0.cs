    foreach (var message in consumer.Consume()) {
        Console.WriteLine(Encoding.UTF8.GetString(message.Value));
        //Saving messages in files
        string lines = Encoding.UTF8.GetString(message.Value);
        System.IO.File.AppendAllText(@"C:\Project\Kafka Research\Kafka_Consumer\Kafka_Consumer\KafkaMessages\Messages.txt", lines);
    }
