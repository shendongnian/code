		public event EventHandler SelectedIndexChanged 
		{
			add { inner.SelectedIndexChanged += value; }
			remove { inner.SelectedIndexChanged -= value; }
		}
