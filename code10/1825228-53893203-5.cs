	using Microsoft.Xrm.Sdk;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	class App_CalcMinMax 
	{
		public void Run()
		{            
			var rebates = new UsageRebate(toCollection(new List<Entity>())); //start with an empty list
			//process various level create and update events
			//and display the results of each event
			//.Process() takes the level #, the min, and the max
			rebates.Process(1, 0, 10000);
			rebates.Process(2, 11000.01m, 20000);
			rebates.Process(3, 21000.01m, 30000);          
			rebates.Process(1, 0, 9000);            
			rebates.Process(2, 10000, 15000);            
			rebates.Process(3, 17000, 35000);
			rebates.Process(3, 12000, 24000);
			rebates.Process(2, 8000, 20000);
			rebates.Process(1, 0, 25000);
			rebates.Process(2, 14000, 19000);
		}
		private class Level
		{
			private Entity e;
			private Level lower;
			private Level upper;
			public int Num => e.GetAttributeValue<int>("new_level");
			public decimal Min => e.GetAttributeValue<Money>("new_minamount").Value;
			public decimal Max => e.GetAttributeValue<Money>("new_maxamount").Value;
			public bool IsValidLower => lower == null ? true : Min > lower.Min;
			public bool IsValidUpper => upper == null ? true : Max < upper.Max;
			public bool IsValid => IsValidLower && IsValidUpper;
			public bool AdjustLower => lower == null ? false : Min - 0.01m != lower.Max;
			public bool AdjustUpper => upper == null ? false : Max + 0.01m != upper.Min;
			
			public Level(Entity e)
			{
				this.e = e;
			}
			public void ValidateLower(Level lower)
			{
				this.lower = lower;
			}
			public void ValidateUpper(Level upper)
			{
				this.upper = upper;
			}
			public void SetMin(decimal value, IOrganizationService service = null)
			{
				e["new_minamount"] = new Money(value);
				//service.Update(e);
			}
			public void SetMax(decimal value, IOrganizationService service = null)
			{
				e["new_maxamount"] = new Money(value);
				//service.Update(e)
			}
			public override string ToString()
			{
				return $" Level: {Num}\tmin: { Min.ToString("N2"),9}\tmax: { Max.ToString("N2"),9}";
			}
		}
		private class UsageRebate
		{
			private IOrganizationService service;
			private EntityCollection ec;
			private IEnumerable<int> levelNums => Levels.Select(l => l.Num);
			public IEnumerable<Entity> Entities => ec.Entities;
			public IEnumerable<Level> Levels => Entities.Select(e => new Level(e));
			public UsageRebate(EntityCollection ec, IOrganizationService service = null)
			{
				this.ec = ec;
				this.service = service;
			}
			public void Process(int num, decimal min, decimal max)
			{
				var target = toEntity(num, min, max);
				var level = new Level(target);                
				Level prior = null;
				Level next = null;
				Console.WriteLine($"Target: {level.ToString()}");
				if (tryGetLevel(level.Num-1,out prior))
				{
					level.ValidateLower(prior);
				}
				if (tryGetLevel(level.Num + 1, out next))
				{
					level.ValidateUpper(next);
				}
				if (level.IsValid)
				{
					if (exists(level.Num))
					{
						update(target);
					}
					else
					{
						add(target);
					}
					if (level.AdjustLower)
					{
						prior.SetMax(level.Min - 0.01m);
					}
					if (level.AdjustUpper)
					{
						next.SetMin(level.Max + 0.01m);
					}
				}
				else
				{
					string message = "Exception: ";
					if (!level.IsValidLower)
					{
						message += $"Level {level.Num} Min is less than Level {prior.Num} Min\n";
					}
					if (!level.IsValidUpper)
					{
						message += $"Level {level.Num} Max exceeds Level {next.Num} Max";                        
					}
					Console.WriteLine(message);
					//throw new Exception(message);
				}
				Console.WriteLine($"Results:\n{ToString()}");
			}
			private bool tryGetLevel(int num, out Level level)
			{
				bool exists = false;
				level = null;
				if (this.exists(num))
				{
					exists = true;
					level = get(num);
				}
				return exists;
			}
		   
			private void add(Entity entity)
			{
				ec.Entities.Add(entity);
				//service.Create(entity);
			}
			private void update(Entity entity)
			{
				var e = get(entity);
				e["new_minamount"] = entity["new_minamount"];
				e["new_maxamount"] = entity["new_maxamount"];
				//service.Update(entity);
			}
			private bool exists(int num)
			{
				return levelNums.Contains(num);
			}
			private Level get(int num)
			{
				return Levels.Where(l => l.Num == num).Single();
			}
			private Entity get(Entity entity)
			{
				return Entities.Where(e => new Level(e).Num == new Level(entity).Num).Single();
			}
			private Entity toEntity(int level, decimal min, decimal max)
			{
				return new Entity
				{
					LogicalName = "new_rebatelevel",
					Id = Guid.NewGuid(),
					Attributes =
					{
						new KeyValuePair<string, object>("new_level", level),
						new KeyValuePair<string, object>("new_minamount", new Money(min)),
						new KeyValuePair<string, object>("new_maxamount", new Money(max))
					}
				};
			}
			public override string ToString()
			{
				var sb = new StringBuilder();
				Levels.ToList().ForEach(l => sb.AppendLine(l.ToString()));
				return sb.ToString();
			}
		}
		private EntityCollection toCollection(List<Entity> list)
		{
			var ec = new EntityCollection();
			ec.EntityName = "new_rebatelevel";
			ec.Entities.AddRange(list);
			return ec;
		}
	}
