	void LogDebug(string Message, params object[] args){
		if(this.DebugEnabled){
			Log.Write(string.Format(Message,args));	
		}
	}
	// 1 with parameters
	LogDebug("GetById({ID}) NOT FOUND", id);
	// 2 interpolated
	LogDebug($"GetById({id}) NOT FOUND");
