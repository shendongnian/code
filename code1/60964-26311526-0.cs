    	public static class Versions
    	{
    		static Version 
    			_NET;
    
    		static SortedList<String,Version>
    			_NETInstalled;
    
    #if NET40
    #else
    		public static bool VersionTry(String S, out Version V)
    		{
    			try
    			{ 
    				V=new Version(S); 
    				return true;
    			}
    			catch
    			{
    				V=null;
    				return false;
    			}
    		}
    #endif
    		const string _NetFrameWorkKey = "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP";
    		static void FillNetInstalled()
    		{
    			if (_NETInstalled == null)
    			{
    				_NETInstalled = new SortedList<String, Version>(StringComparer.InvariantCultureIgnoreCase);
    				RegistryKey
    					frmks = Registry.LocalMachine.OpenSubKey(_NetFrameWorkKey);
    				string[]
    					names = frmks.GetSubKeyNames();
    				foreach (string name in names)
    				{
    					if (name.StartsWith("v", StringComparison.InvariantCultureIgnoreCase) && name.Length > 1)
    					{
    						string
    							f, vs;
    						Version
    							v;
    						vs = name.Substring(1);
    						if (vs.IndexOf('.') < 0)
    							vs += ".0";
    #if NET40
    						if (Version.TryParse(vs, out v))
    #else
    						if (VersionTry(vs, out v))
    #endif
    						{
    							f = String.Format("{0}.{1}", v.Major, v.Minor);
    #if NET40
    							if (Version.TryParse((string)frmks.OpenSubKey(name).GetValue("Version"), out v))
    #else
    							if (VersionTry((string)frmks.OpenSubKey(name).GetValue("Version"), out v))
    #endif
    							{
    								if (!_NETInstalled.ContainsKey(f) || v.CompareTo(_NETInstalled[f]) > 0)
    									_NETInstalled[f] = v;
    							}
    							else
    							{ // parse variants
    								Version
    									best = null;
    								if (_NETInstalled.ContainsKey(f))
    									best = _NETInstalled[f];
    								string[]
    									varieties = frmks.OpenSubKey(name).GetSubKeyNames();
    								foreach (string variety in varieties)
    #if NET40
    									if (Version.TryParse((string)frmks.OpenSubKey(name + '\\' + variety).GetValue("Version"), out v))
    #else
    									if (VersionTry((string)frmks.OpenSubKey(name + '\\' + variety).GetValue("Version"), out v))
    #endif
    									{
    										if (best == null || v.CompareTo(best) > 0)
    										{
    											_NETInstalled[f] = v;
    											best = v;
    										}
    										vs = f + '.' + variety;
    										if (!_NETInstalled.ContainsKey(vs) || v.CompareTo(_NETInstalled[vs]) > 0)
    											_NETInstalled[vs] = v;
    									}
    							}
    						}
    					}
    				}
    			}
    		} // static void FillNetInstalled()
    
    		public static Version NETInstalled
    		{
    			get
    			{
    				FillNetInstalled();
    				return _NETInstalled[_NETInstalled.Keys[_NETInstalled.Count-1]];
    			}
    		} // NETInstalled
    
    		public static Version NET
    		{
    			get
    			{
    				FillNetInstalled();
    				string
    					clr = String.Format("{0}.{1}", Environment.Version.Major, Environment.Version.Minor);
    				Version
    					found = _NETInstalled[_NETInstalled.Keys[_NETInstalled.Count-1]];
    				if(_NETInstalled.ContainsKey(clr))
    					return _NETInstalled[clr];
    
    				for (int i = _NETInstalled.Count - 1; i >= 0; i--)
    					if (_NETInstalled.Keys[i].CompareTo(clr) < 0)
    						return found;
    					else
    						found = _NETInstalled[_NETInstalled.Keys[i]];
    				return found;
    			}
    		} // NET
    	}
    
    
