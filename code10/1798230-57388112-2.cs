    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Configuration.Binder;
    using System.IO;
    using Microsoft.Extensions.Logging;
    
    namespace MyApp.Services
    {
        public class FileService : IFileService
        {
            private readonly IFileProvider _fileProvider;
            private readonly IHostingEnvironment _hostingEnvironment;
            private readonly IConfiguration _config;
            private readonly ILogger<FileService> _logger;
            string defaultfolderPath = ConfigurationManager.AppSetting["DefaultDrivePath"];
            public FileService(IFileProvider fileProvider, IHostingEnvironment hostingEnvironment, IConfiguration config, ILogger<FileService> logger)
            {
                _fileProvider = fileProvider;
                _hostingEnvironment = hostingEnvironment;
                _config = config;
                _logger = logger;
            }
            public void CreateDirectoryStructure(string drivePath = "")
            {     
                if (drivePath.Equals(""))
                {
                    drivePath = ConfigurationManager.AppSetting["DefaultDrivePath"];
                    _logger.LogInformation($"Default folder path will be picked {drivePath}");
                }
                foreach (var item in _config.GetSection("FolderStructure").GetChildren())
                {
                    CreateFolder(item.Key, drivePath);
                    foreach (var i in _config.GetSection(item.Path).GetChildren())
                    {
                        if (i.Key != "*")
                            CreateFolder(i.Key, $"{drivePath}/{item.Key}");
                    }
                }
            }
            public void CreateFolder(string name, string path = "")
            {
                string fullPath = string.IsNullOrEmpty(path) ? $"{defaultfolderPath}/{name}" : $"{path}/{name}";
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    _logger.LogInformation($"Directory created at {fullPath} on {DateTime.Now}");
                }
            }
            public void CreateFile(string name, string path = "")
            {
                string fullPath = string.IsNullOrEmpty(path) ? $"{defaultfolderPath}/{name}" : $"{path}/{name}";
                if (!File.Exists(fullPath))
                {
                    File.Create(fullPath);
                    _logger.LogInformation($"File created at {fullPath} on {DateTime.Now}");
                }
            }
            public bool CheckFolderExists(string path)
            {
                string fullPath = string.IsNullOrEmpty(path) ? defaultfolderPath : path;
                return Directory.Exists(fullPath);
            }
    
            public bool CheckFileExists(string path)
            {
                string fullPath = string.IsNullOrEmpty(path) ? defaultfolderPath : path;
                return File.Exists(fullPath);
            }
           
        }
    }
