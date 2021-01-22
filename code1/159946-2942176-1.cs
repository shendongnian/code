        using System;
        using Nini;
        using Nini.Ini;
        using Nini.Config;
        using System.IO;
        namespace CommandLine
        {
            class Test
            {
                static void Main(string[] Args)
                {
                    string myIniTxt = Path.Combine(Environment.CurrentDirectory, "ini.txt");
                    IniConfigSource ini = new IniConfigSource(myIniTxt);
                    IConfig config = ini.Configs["NETWORK"];
                    config.Set("pcConnectAddr", "myValueForPcConnectAdd");
                    config.Set("pcPort", "myValueForPcPort");
                    ini.Save();
                }
            }
        }
