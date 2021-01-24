    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictSettings = new Dictionary<string, string>();
            string MyAlpa = "";
            string MyBravo = "";
            string MyCharlie = "";
            string MyDelta = "";
            var lines = File.ReadAllLines(@"C:\Users\xxx\source\repos\ConsoleApp4\ConsoleApp4\Files\Sample.txt");
            for (var i = 0; i < lines.Length; i += 1)
            {
                var line = lines[i];
                //DoesLineExist(line);
                if (!string.IsNullOrEmpty(line) && line.Contains(":"))
                {
                    string settingKey = line.Split(':')[0];
                    string settingValue = line.Split(':')[1];
                    dictSettings.Add(settingKey, settingValue);
                }
            }
            MyAlpa = dictSettings.ContainsKey("SettingA") ? dictSettings["SettingA"] : "";
            MyBravo = dictSettings.ContainsKey("SettingB") ? dictSettings["SettingB"] : "";
            MyCharlie = dictSettings.ContainsKey("SettingC") ? dictSettings["SettingC"] : "";
            MyDelta = dictSettings.ContainsKey("SettingD") ? dictSettings["SettingD"] : "";
            Console.WriteLine(MyAlpa);
            Console.WriteLine(MyBravo);
            Console.WriteLine(MyCharlie);
            Console.WriteLine(MyDelta);
            Console.ReadLine();
        }
        //private static void DoesLineExist(string line)
        //{
        //    if (!string.IsNullOrEmpty(line) && line.Contains(":"))
        //    {
        //        string settingKey = line.Split(':')[0];
        //        string settingValue = line.Split(':')[1];
        //        dictSettings.Add(settingKey, settingValue);
        //    }
        //}
    }
