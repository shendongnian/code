	using Data.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Web.Http;
	namespace Data.Controllers
	{
		public class DataController : Controller
		{
			// some data access provider using entity framework or ADO.NET
			DataProvider provider;
			
			public DataController()
			{
				provider = new Provider	();
			}
			[HttpPost]
			public IActionResult PostData([FromBody]Item data)
			{
				provider.Add(data);
				return Ok();
			}
		}
	} 
