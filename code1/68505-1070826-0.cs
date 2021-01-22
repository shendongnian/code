	///<summary>
	///</summary>
	public interface IPlugin {
		///<summary>
		///</summary>
		string Name { get; }
		///<summary>
		///</summary>
		string Description { get; }
		///<summary>
		///</summary>
		string Author { get; }
		///<summary>
		///</summary>
		string Version { get; }
		///<summary>
		///</summary>
		IPluginHost Host { get; set; }
		///<summary>
		///</summary>
		void Init();
		///<summary>
		///</summary>
		void Unload();
		///<summary>
		///</summary>
		///<returns></returns>
		IDictionary<int, string> GetOptions();
		///<summary>
		///</summary>
		///<param name="opcion"></param>
		void ExecuteOption(int option);
	}
	///<summary>
	///</summary>
	public interface IPluginHost {
		///<summary>
		///</summary>
		IDictionary<string, object> Variables { get; }
		///<summary>
		///</summary>
		///<param name="plugin"></param>
		void Register(IPlugin plugin);
	}
