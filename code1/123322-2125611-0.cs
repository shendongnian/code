using Nini;
using Nini.Config;
namespace niniDemo{
   public class niniDemoClass{
       public bool LoadIni(){
            string configFileName = "demo.ini";
            IniConfigSource configSource = new IniConfigSource(configFileName);
            IConfig demoConfigSection = configSource.Configs["Demo"];
            string demoVal = demoConfigSection.Get("demoVal", string.Empty);
       }
   }
}
