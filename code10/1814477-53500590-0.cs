    public class Mapinfo
    {
       private object mapinfoinstance;
       public Mapinfo(object mapinfo)
       {
         this. mapinfoinstance = mapinfo;
       }
     
       public static Mapinfo CreateInstance()
       {
            Type mapinfotype = Type.GetTypeFromProgID(&quot;Mapinfo.Application&quot;);
            object instance = Activator.CreateInstance(mapinfotype);
            return new Mapinfo(instance);
        }
     
        public void Do(string command)
        {
              parameter[0] = command;
              mapinfoType.InvokeMember(&quot;Do&quot;,
                        BindingFlags.InvokeMethod,
                        null, instance, parameter);
         }
     
         public string Eval(string command)
         {
             parameter[0] = command;
             return (string)mapinfoType.InvokeMember(&quot;Eval&quot;, BindingFlags.InvokeMethod,
                                 null,instance,parameter);
          }
    }
