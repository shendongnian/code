    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System" #>
    <#@ output extension=".g.cs" #>
    using System;
    namespace Foo.Bar
    {
        public static partial class Constants
        {
            public static DateTime CompilationTimestampUtc { get { return new DateTime(<# Write(DateTime.UtcNow.Ticks.ToString()); #>L, DateTimeKind.Utc); } }
    	}
    }
