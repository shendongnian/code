	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;
	using NetCoreWebApplication1.Dto;
	using NetCoreWebApplication1.Models;
	namespace NetCoreWebApplication1.Repository
	{
		public class MasterRepository : IMasterRepository
		{
			private readonly PrDbContext _context;
			public MasterRepository(PrDbContext context)
			{
				_context = context;
			}
			// Employee
			public async Task<List<Employee>> GetAllEmployee()
			{
				var data = await _context.Employee.ToListAsync();
				return data;
			}
			public async Task<Employee> GetEmployee(int id)
			{
				var data = await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
				return data;
			}
			public async Task<Employee> AddEmployee(Employee data)
			{
				await _context.Employee.AddAsync(data);
				await _context.SaveChangesAsync();
				return data;
			}
			public async Task<bool> EmployeeExists(string entityCode, string empCode)
			{
				if (await _context.Employee.AnyAsync(x =>
					x.EntityCode == entityCode &&
					x.EmpCode == empCode))
					return true;
				return false;
			}
			// Generic methods
			public void Add<T>(T entity) where T : class
			{
				_context.Add(entity);
			}
			public void Delete<T>(T entity) where T : class
			{
				_context.Remove(entity);
			}
			public async Task<bool> SaveAll()
			{
				return await _context.SaveChangesAsync() > 0;
			}
		}
	}
