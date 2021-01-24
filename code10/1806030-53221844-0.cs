		public virtual string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}
		
		/// <summary> </summary>
		public virtual System.Type NameType
		{
			get
			{
				return System.Type.GetType( this.Name );
			}
			set
			{
				if(value.Assembly == typeof(int).Assembly)
					this.Name = value.FullName.Substring(7);
				else
					this.Name = HbmWriterHelper.GetNameWithAssembly(value);
			}
        }
