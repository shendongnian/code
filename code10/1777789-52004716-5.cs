	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using NetCoreWebApplication1.Dto;
	using NetCoreWebApplication1.Repository;
	using NetCoreWebApplication1.Other;
	using NetCoreWebApplication1.Models;
	namespace NetCoreWebApplication1.Controller
	{
		[Route("api/[controller]")]
		[ApiController]
		public class EmployeeController : ControllerBase
		{
			private readonly IMasterRepository _repo;
			public EmployeeController(IMasterRepository repo)
			{
				_repo = repo;
			}
			[HttpPost("add")]
			public async Task<IActionResult> AddEmployee(EmployeeForAddDto emp)
			{
				if (await _repo.EmployeeExists(emp.EntityCode, emp.EmpCode))
					ModelState.AddModelError("Employee", "Employee is duplicate (EntityCode + EmpCode)");
				if (!ModelState.IsValid)
					return BadRequest(ModelState);
				Employee employeeToAdd = emp.MapFromEmployeeForAddDto();
				await _repo.AddEmployee(employeeToAdd);
				return StatusCode(201);
			}
			[HttpGet("{id}")]
			public async Task<IActionResult> GetEmployee(int id)
			{
				var data = await _repo.GetEmployee(id);
				if (data == null) return NotFound();
				return Ok(data.MapToEmployeeForShortDto());
			}
			[HttpGet]
			public async Task<IActionResult> GetAllEmployee()
			{
				var data = await _repo.GetAllEmployee();
				//var dataDto = data.Select(x => x.MapToEmployeeForShortDto());
				var dataDto = data.Select(x => x.MapToEmployeeForListDto());
				return Ok(dataDto);
			}
		}
	}
