     using Microsoft.Hadoop.Avro.Container;
     // ...
     using (var reader = AvroContainer.CreateGenericReader(myBlob))
     {
        while (reader.MoveNext())
        {
           foreach (dynamic record in reader.Current.Objects)
           {
              var bodyText = Encoding.UTF8.GetString(record.Body);
              log.Info($"AvroRecord = {bodyText}");
           }
        }
     }
