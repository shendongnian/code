    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace ConsoleApp2
    {
        class AccessPoint
        {
            public string SSID { get; set; }
            public string BSSID { get; set; }
            public byte Signal { get; set; }
        }
    
        class Program
        {
            private static async Task Main(string[] args)
            {
                var apList = await GetSignalOfNetworks();
    
                foreach (var ap in apList)
                {
                    WriteLine($"{ap.BSSID} - {ap.Signal} - {ap.SSID}");
                }
    
                Console.ReadKey();
            }
    
            private static async Task<AccessPoint[]> GetSignalOfNetworks()
            {
                string result = await ExecuteProcessAsync(@"C:\Windows\System32\netsh.exe", "wlan show networks mode=bssid");
    
                return Regex.Split(result, @"[^B]SSID \d+").Skip(1).SelectMany(network => GetAccessPointFromNetwork(network)).ToArray();
            }
    
            private static AccessPoint[] GetAccessPointFromNetwork(string network)
            {
                string withoutLineBreaks = Regex.Replace(network, @"[\r\n]+", " ").Trim();
                string ssid = Regex.Replace(withoutLineBreaks, @"^:\s+(\S+).*$", "$1").Trim();
    
                return Regex.Split(withoutLineBreaks, @"\s{4}BSSID \d+").Skip(1).Select(ap => GetAccessPoint(ssid, ap)).ToArray();
            }
    
            private static AccessPoint GetAccessPoint(string ssid, string ap)
            {
                string withoutLineBreaks = Regex.Replace(ap, @"[\r\n]+", " ").Trim();
                string bssid = Regex.Replace(withoutLineBreaks, @"^:\s+([a-f0-9]{2}(:[a-f0-9]{2}){5}).*$", "$1").Trim();
                byte signal = byte.Parse(Regex.Replace(withoutLineBreaks, @"^.*(Signal|Sinal)\s+:\s+(\d+)%.*$", "$2").Trim());
    
                return new AccessPoint
                {
                    SSID = ssid,
                    BSSID = bssid,
                    Signal = signal,
                };
            }
    
            private static async Task<string> ExecuteProcessAsync(string cmd, string args = null)
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = cmd,
                        Arguments = args,
                        RedirectStandardInput = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        StandardOutputEncoding = Encoding.UTF8,
                    }
                };
    
                process.Start();
    
                string result = await process.StandardOutput.ReadToEndAsync();
    
                process.WaitForExit();
    
    #if DEBUG
                if (result.Trim().Contains("The Wireless AutoConfig Service (wlansvc) is not running."))
                {
                    return await GetFakeData();
                }
    #endif
    
                return result;
            }
    
            private static async Task<string> GetFakeData()
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "ConsoleApp2.FakeData.txt";
    
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
    
            private static void WriteLine(string str)
            {
                Console.WriteLine(str);
            }
        }
    }
