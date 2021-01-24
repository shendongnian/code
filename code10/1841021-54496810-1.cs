    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static async Task Main(string[] args)
            {
                try
                {
                    string jsonFilePath = "1.json";
    
                    string objName = "arena_id";
    
                    int obj = await GetObjectAsync<int>(jsonFilePath, objName, CancellationToken.None);
    
                    //string objName = "string_array";
    
                    //string[] obj = await GetObjectAsync<string[]>(jsonFilePath, objName, CancellationToken.None);
    
                    System.Diagnostics.Debugger.Break();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    System.Diagnostics.Debugger.Break();
                }
            }
    
            static async Task<T> GetObjectAsync<T>(string jsonFilePath, string objName, CancellationToken cancellationToken)
            {
                using (TextReader tr = File.OpenText(jsonFilePath))
                {
                    using (JsonTextReader jr = new JsonTextReader(tr))
                    {
                        while (await jr.ReadAsync(cancellationToken))
                        {
                            if (jr.TokenType == JsonToken.PropertyName && $"{jr.Value}" == objName)
                            {
                                StringBuilder sb = new StringBuilder();
    
                                using (TextWriter tw = new StringWriter(sb))
                                {
                                    using (JsonTextWriter jw = new JsonTextWriter(tw))
                                    {
                                        await jr.ReadAsync(cancellationToken);
                                        //write current JsonReader's token with children
                                        await jw.WriteTokenAsync(jr, cancellationToken); 
                                        await jw.FlushAsync(cancellationToken);
    
                                        string objJson = sb.ToString();
                                        return await Task.Run(() => JsonConvert.DeserializeObject<T>(objJson));
                                    }
                                }
                            }
                        }
    
                        throw new Exception($"'{objName}' not found...");
                    }
                }
            }
        }
    }
