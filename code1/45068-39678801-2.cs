    namespace Foo.Bar
    {
        using Microsoft.FSharp.Core;
        using System;
    
        [CompilationMapping(SourceConstructFlags.Module)]
        public static class StringExt
        {
            [CompilationSourceName("ToInteger")]
            public static long ToInteger(string s) => 
                long.Parse(s);
        }
    }
    
