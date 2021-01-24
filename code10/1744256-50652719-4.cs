	class MechDef
	{
		public Limb Head        { get; set; }
		public Limb LeftArm     { get; set; }
		public Limb RightArm    { get; set; }
		public Limb LeftTorso   { get; set; }
		public Limb RightTorso  { get; set; }
		public Limb CenterTorso { get; set; }
		public Limb RightLeg    { get; set; }
		public Limb LeftLeg     { get; set; }
	
		private readonly Dictionary<string, PropertyWrapper<Limb>> Properties;
		
		public MechDef()
		{
			Properties = new Dictionary<string, PropertyWrapper<Limb>>
			{
				{"Head",       new PropertyWrapper<Limb>( () => Head,        v => Head = v )       },
				{"LeftArm",    new PropertyWrapper<Limb>( () => LeftArm,     v => LeftArm = v )    },
				{"RightArm",   new PropertyWrapper<Limb>( () => RightArm,    v => RightArm = v )   },
				{"CenterTorso",new PropertyWrapper<Limb>( () => CenterTorso, v => CenterTorso = v )},
				{"RightTorso", new PropertyWrapper<Limb>( () => RightTorso,  v => RightTorso = v ) },
				{"LeftTorso",  new PropertyWrapper<Limb>( () => LeftTorso,   v => LeftTorso = v )  },
				{"RightLeg",   new PropertyWrapper<Limb>( () => RightLeg,    v => RightLeg = v )   },
				{"LeftLeg",    new PropertyWrapper<Limb>( () => LeftLeg,     v => LeftLeg = v )    }
			};
			
			foreach (var property in Properties) property.Value.Value = new Limb();
		}
	
		public Limb this[string name]
		{
			get
			{
				return Properties[name].Value;
			}
			set
			{
				Properties[name].Value = value;
			}
		}
	}
