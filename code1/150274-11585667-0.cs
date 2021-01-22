		public IEnumerable<T> GetParents(T vertexToFind)
		{
			IEnumerable<T> parents = null;
			if (this.graph.Edges != null)
			{
				parents = this.graph
					.Edges
					.Where(x => x.Target.Equals(vertexToFind))
					.Select(x => x.Source);
			}
			return parents;
		}
