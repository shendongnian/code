    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.Devices;
    using Microsoft.Azure.Devices.Common.Exceptions;
    
    // For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
    
    namespace WebApplication1.Controllers
    {
        public class ManageDevices : Controller
        {
            public static string IOTHUBSTRING = "HostName=[IOT HUB NAME].azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=[KEY]";
    
    
            // GET: /<controller>/
            public string Index()
            {
                return "This is my default action...";
            }
    
            public IActionResult GetDevices()
            {
                GetDevicesAsync();
                return View();
            }
    
            public async static Task<IEnumerable> GetDevicesAsync(int deviceCount = 8)
            {
    
                var regManager = RegistryManager.CreateFromConnectionString(IOTHUBSTRING);
    
                var devices = await regManager.GetDevicesAsync(deviceCount);
    
                return devices;
            }
        }
    }
