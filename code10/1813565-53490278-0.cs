    public class JsonModelFormatter : JsonMediaTypeFormatter
    {
        public override System.Threading.Tasks.Task<Object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger, CancellationToken cancellationToken)
        {
            System.Threading.Tasks.Task<Object> baseTask = base.ReadFromStreamAsync(type, readStream, content, formatterLogger, cancellationToken);
            
            if (baseTask.Result != null)
            {
                var properties = baseTask.Result.GetType().GetProperties();
                foreach (var property in properties)
                {
                    //Check Property attribute and decide if you need to format it
                    if (property.CustomAttributes.Where (x=> you condition here))
                    {
                        if (property.CanWrite && property.GetValue(baseTask.Result, null) != null)
                        {
                            var propValue = ((string)property.GetValue(baseTask.Result, null));
                           //Update propValue here 
                           property.SetValue(baseTask.Result, newPropValue);
                        }
                    }
                }
            }
            return baseTask;
        }
        public override bool CanReadType(Type type)
        {
            return true;
        }
    }
    
