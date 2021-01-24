	[System.Serializable]
	public class PlayerData
	{
        [SerializeField]
		public string Name {get; protected set;}
        [SerializeField]
		public uint Attack {get; protected set;}
        [SerializeField]
		public uint Defense {get; protected set;}
        [SerializeField]
		public uint Armor {get; protected set;}
        [SerializeField]
		public uint MovementSpeed {get; protected set;}
        [SerializeField]
		public uint MagicLevel {get; protected set;}
		public static PlayerData Deserialize(string obj)
		{
		    return JsonUtility.FromJson<PlayerData>(obj);
		}
	}
