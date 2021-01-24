    class SampleResourceHandler : ResourceHandler
    {
        public bool CanLoadResource(ResourceParams parameters)
        {
            if (parameters.ResourceType == ResourceType.IMAGE)
            {
                Console.WriteLine("image URL: " + parameters.URL);
            }
    
            return true;
        }
    }
