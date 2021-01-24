    <#@ template hostspecific="false" language="C#" #>
    <#@ output extension=".cs" #>
    <#@ include file="Common.t4" #>
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using WebApplication3.Models;
    
    namespace WebApplication3.Controllers
    {
    <#
    foreach (string entity in GetEntities())
    {
    #>
        [Produces("application/json")]
        [Route("api/<#=entity#>")]
        public class <#=entity#>Controller : Controller
        {
            // GET: api/<#=entity#>
            [HttpGet]
            public IEnumerable<<#=entity#>Model> Get()
            {
                return new <#=entity#>Model[] { new <#=entity#>Model(), new <#=entity#>Model() };
            }
    
            // GET: api/<#=entity#>/5
            [HttpGet("{id}", Name = "Get")]
            public <#=entity#>Model Get(int id)
            {
                return new <#=entity#>Model();
            }
            
            // POST: api/<#=entity#>
            [HttpPost]
            public void Post([FromBody]<#=entity#>Model value)
            {
            }
            
            // PUT: api/<#=entity#>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody]<#=entity#>Model value)
            {
            }
            
            // DELETE: api/<#=entity#>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
        }
    
    <#
    }
    #>
    }
