    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    namespace TestClient
    {
           
        public class AppSettings
        {
            private AppSettings()
            {
                // marked as private to prevent outside classes from creating new.
            }
    
            private static string _jsonSource;
            private static AppSettings _appSettings = null;
            public static AppSettings Default
            {
                get
                {
                    if (_appSettings == null)
                    {
                        var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    
                        _jsonSource = $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}appsettings.json";
    
                        var config = builder.Build();
                        _appSettings = new AppSettings();
                        config.Bind(_appSettings);
                    }
    
                    return _appSettings;
                }
            }
    
            public void Save()
            {
                // open config file
                string json = JsonConvert.SerializeObject(_appSettings);
    
                //write string to file
                System.IO.File.WriteAllText(_jsonSource, json);
            }
    
            public string Theme { get; set; }
        }
    }
