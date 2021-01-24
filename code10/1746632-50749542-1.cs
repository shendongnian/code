    private object _lock = new object();
    
        public EnumConversionStatus GenerateRmsImportFiles(int submissionId)
                {
                    lock (_lock)
                    {
                        using (var client = new RMSConversionService.RMSConversionServiceClient())
                        {
                            var result = client.GenerateRmsImportFiles(submissionId);
                            client.Close();
                            return result;
                        }
                    }
                }
    
    
        public EnumConversionStatus GenerateAirImportFiles(int submissionId)
                {
                    lock (_lock)
                    {
                        using (var client = new AIRConversionService.AirConversionServiceClient())
                        {
                            var result = client.GenerateAirImportFiles(submissionId);
                            return result;
                        }
                    }
                }
