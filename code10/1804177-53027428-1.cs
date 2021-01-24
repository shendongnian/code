    <#@ template hostspecific="false" language="C#" #>
    <#@ output extension=".cs" #>
    <#@ include file="Common.t4" #>
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace WebApplication3.Models
    {
    <#
    foreach (string entity in GetEntities())
    {
    #>
        public class <#=entity#>Model
        {
    <#
    	foreach (FieldDefinition fieldDefinition in GetEntityFields(entity))
    	{
    #>
    		public <#= fieldDefinition.Type.FullName#> <#= fieldDefinition.Name#> { get; set; }
    <#
    	}
    #>
        }
    
    <#
    }
    #>
    }
