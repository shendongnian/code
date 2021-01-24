	[System.Serializable]
	public class PlayerData
	{
		[SerializeField]
		protected string _name 
		
		public string Name {get { return _name;}}
		[SerializeField]
		protected uint _attack;
		
		public uint Attack {get { return _attack;}}
		[SerializeField]
		protected uint _defense;
		
		public uint Defense {get { return _defense;}}
		[SerializeField]
		protected uint _armor;
		
		public uint Armor {get { return _armor;}}
		[SerializeField]
		protected uint _movementSpeed;
		
		public uint MovementSpeed {get { return _movementSpeed;}}
		[SerializeField]
		protected uint _magicLevel;
		
		public uint MagicLevel {get { return _magicLevel;}}
		public static PlayerData Deserialize(string obj)
		{
			return JsonUtility.FromJson<PlayerData>(obj);
		}
	}
