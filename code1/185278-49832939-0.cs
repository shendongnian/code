    using System.ComponentModel;
    using System.Diagnostics;
    using System.Reflection;
    internal static class AssemblyExtensions
    {
        public static bool IsOptimized(this Assembly asm)
        {
            var att = asm.GetCustomAttribute<DebuggableAttribute>();
            return att == null || att.IsJITOptimizerDisabled == false;
        }
    }
