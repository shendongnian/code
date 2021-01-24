    <#@ template debug="true" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ output extension=".cs" #>
    <#
    	var hostFile = this.Host.TemplateFile;
    	var entityName = System.IO.Path.GetFileNameWithoutExtension(hostFile).Replace("Controller","");
    	var directoryName = System.IO.Path.GetDirectoryName(hostFile);
    	var fileName = directoryName + "\\" + entityName + ".cs";
    #>
    /// <summary>
    /// <#= entityName #> controller
    /// </summary>
    [Route("api/[controller]")]
    public class <#= entityName #>Controller : Controller
    {
        private readonly LocalDBContext localDBContext;
        private UnitOfWork unitOfWork;
    
        /// <summary>
        /// Constructor
        /// </summary>
        public <#= entityName #>Controller(LocalDBContext localDBContext)
        {
            this.localDBContext = localDBContext;
            this.unitOfWork = new UnitOfWork(localDBContext);
        }
    
        /// <summary>
        /// Get <#= Pascal(entityName) #> by Id
        /// </summary>
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(<#= entityName #>Model))]
        public IActionResult GetById(int id)
        {
            var <#= Pascal(entityName) #> = unitOfWork.<#= entityName #>Repository.GetById(id);
            if (<#= Pascal(entityName) #> == null)
            {
                return NotFound();
            }
    
            var res = AutoMapper.Mapper.Map<<#= entityName #>Model>(<#= Pascal(entityName) #>);
            return Ok(res);
        }
    
        /// <summary>
        /// Post an <#= Pascal(entityName) #>
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody]<#= entityName #>Model <#= Pascal(entityName) #>)
        {
            Usuario u = AutoMapper.Mapper.Map<<#= entityName #>>(<#= Pascal(entityName) #>);
            var res = unitOfWork.<#= entityName #>Repository.Add(u);
    
            if (res?.Id > 0)
            {
                return Ok(res);
            }
    
            return BadRequest();
    
        }
    
        /// <summary>
        /// Edit an <#= Pascal(entityName) #>
        /// </summary>
        [HttpPut]
        public IActionResult Put([FromBody]<#= entityName #>Model <#= Pascal(entityName) #>)
        {
            if (unitOfWork.<#= entityName #>Repository.GetById(<#= Pascal(entityName) #>.Id) == null)
            {
                return NotFound();
            }
    
            var u = AutoMapper.Mapper.Map<<#= entityName #>>(<#= Pascal(entityName) #>);
    
            var res = unitOfWork.<#= entityName #>Repository.Update(u);
    
            return Ok(res);
    
        }
    
        /// <summary>
        /// Delete an <#= Pascal(entityName) #>
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
    
            if (unitOfWork.<#= entityName #>Repository.GetById(id) == null)
            {
                return NotFound();
            }
    
            unitOfWork.<#= entityName #>Repository.Delete(id);
    
            return Ok();
    
        }
    }
    <#+
        public string Pascal(string input)
        {
            return input.ToCharArray()[0].ToString() + input.Substring(1);
        }
    #>
