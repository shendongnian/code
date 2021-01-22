		bool _hasProp = true;
		protected override object OnRequiredPropertyNotFound(string name)
		{
			if (name == "prop")
			{
				_hasProp = false;
				return null; // note that this will still not make prop null
			}
			return base.OnRequiredPropertyNotFound(name);
		}
		[ConfigurationProperty("prop", IsRequired = true)]
		public string Prop
		{
			get { return _hasProp ? (string) this["prop"] : null; }
		}
