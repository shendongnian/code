		private class EntityRole
		{
			public int EntityId { get; set; }
			public int RoleId { get; set; }
		}
		private IList<EntityRole> GetSourceEntityRole()
		{
			var list = new List<EntityRole>() {new EntityRole(){EntityId = 123, RoleId = 1},
											   new EntityRole(){EntityId = 123, RoleId = 2},
											   new EntityRole(){EntityId = 123, RoleId = 3},
											   new EntityRole(){EntityId = 123, RoleId = 4}};
			list.Reverse();
			return list;
		}
		private IList<EntityRole> GetEmptyEntityRole()
		{
			var list = new List<EntityRole>();
			return list;
		}
		public void TestToDelete()
		{
			var source = this.GetSourceEntityRole();
			var destination = this.GetEmptyEntityRole();
			this.TestLeftJoin(source, destination);
		}
		private void TestLeftJoin(IList<EntityRole> source, IList<EntityRole> destination)
		{
			var inserting = this.GetMissing(source, destination);
			var deleting = this.GetMissing(destination, source);
			this.Enumerate("Source", source);
			this.Enumerate("Destination", destination);
			this.Enumerate("Deleting", deleting);
			this.Enumerate("Inserting", inserting);
		}
		private IEnumerable<EntityRole> GetMissing(IList<EntityRole> sourceEntities, IList<EntityRole> destinationEntities)
		{
			return from source in sourceEntities
				   join dest in destinationEntities on source.RoleId equals dest.RoleId into joined
				   from source2 in joined.DefaultIfEmpty()
				   where source2 == null
				   select source;
		}
		private void Enumerate(string source, IEnumerable<EntityRole> roles)
		{
			foreach (var item in roles)
			{
				Console.WriteLine("{0}:{1}", source, item.RoleId);
			}
		}
