     private async Task<string> WriteCSV<ViewModel>(IEnumerable<ViewModel> viewModels, string path)
                {
                    Type itemType = typeof(ViewModel);
                    var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                        .OrderBy(p => p.Name);
        
                    var blobName = string.Empty;
        
                    using (var ms = new MemoryStream())
                    {
        
                        using (var writer = new System.IO.StreamWriter(ms))
                        {
                            writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));
        
                            foreach (var item in viewModels)
                            {
        
                                writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                            }
        }
       
     }
        }
