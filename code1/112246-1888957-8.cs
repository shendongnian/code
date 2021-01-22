        public static class Configuration
    {
    	private static Func<IConfigReader> _configReaderFunc = () => new StaticConfigReader;
    	
    	public static Func<IConfigReader> GetConfiguration
    	{
    		get { return _configReaderFunc; }
    	}
    	
    	public static IDisposable CreateConfigScope(IConfigReader reader)
    	{
    		return new ConfigReaderScope(() => reader);
    	}
    	
    	private class ConfigReaderScope : IDisposable
    	{
    		private readonly Func<IConfigReader> _oldReaderFunc;
    		
    		public ConfigReaderScope(Func<IConfigReader> newReaderFunc)
    		{
    			this._oldReaderFunc = _configReaderFunc;
    			_configReaderFunc = newReaderFunc;
    		}
    		
    		public void Dispose()
    		{
    			_configReaderFunc = this._oldReaderFunc;
    		}
    	}
    }
