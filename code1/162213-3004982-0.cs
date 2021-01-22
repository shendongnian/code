    namespace shell
    {
       static class program
       {
          [dllimport("kernel32.dll", charset = charset.auto, setlasterror = true)]
          public static extern bool setenvironmentvariable(string lpname, string lpvalue);
    
          private static string joinargstosinglestring(string[] args)
          {
             string s = string.empty;
             for (int i = 0; i < args.length; ++i)
             {
                if (!string.isnullorempty(s))
                {
                   s += " ";
                }
                s += "\"" + args[i] + "\"";
             }
             return s;
          }
    
          [stathread]
          static void main(string[] args)
          {    
             string pathbefore = environment.getenvironmentvariable("path");
             string wewant = util.paths.getapplicationdatadir() + ";" + pathbefore;
             setenvironmentvariable("path", wewant);
    
             Process process = Process.Start(".\\WonderApp.exe", joinArgsToSingleString(args));
          }
       }
    }
