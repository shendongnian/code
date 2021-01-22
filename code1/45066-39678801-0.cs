    namespace Foo.Bar
    {
        using Microsoft.FSharp.Core;
        using System;
    
        [CompilationMapping(SourceConstructFlags.Module)]
        public static class StringExt
        {
            public static long String.ToInteger.Static(string s) => 
                long.Parse(s);
        }
    }
    
