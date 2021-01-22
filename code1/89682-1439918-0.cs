    using System;
    using System.Diagnostics;
    using System.Security;
    using System.Security.Permissions;
    
    public class PluginSection : CodeAccessSecurityAttribute
    {
        public PluginSection(SecurityAction action)
            : base(action)
        {
        }
    
        public override IPermission CreatePermission()
        {
            // Removed for demo purposes
            return null;
        }
    
    }
    
    class NotApplied {}
    
    [PluginSection(SecurityAction.Demand)]
    class Applied{}
    
    class Test
    {
        static void Main()
        {
            Console.WriteLine(IsPluginSection(typeof(Applied));
            Console.WriteLine(IsPluginSection(typeof(NotApplied));
        }
        static void IsPluginSection(Type type)
        {
            return type.IsDefined(typeof(PluginSection), false)
        }
    }
