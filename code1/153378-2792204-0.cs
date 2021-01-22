    <#@ template language="C#" #>
    <#@ output extension=".cs" #>
    using System;
    
    namespace MyNamespace
    {
        [Flags]
        public enum MyEnumeration : ulong
        {
    <#
        ulong value = 1;
        for(int i = 1; i <= 64; i++)
        {
    #>
            Flag<#= i #> = <#= string.Format("0x{0:X8}", value) #>,
    <#
            value = value << 1;
        }
    #>
        }
    }
