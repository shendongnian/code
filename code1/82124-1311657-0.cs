		public object CachedMethodCall(MethodInfo realMethod, params object[] realMethodParams)
		{
			string cacheKey = CachingHelper.GenereateCacheKey(realMethod, realMethodParams);
			object result = _CacheManager.GetData(cacheKey);
			if (result == null)
			{
				result = realMethod.Invoke(_RealService, BindingFlags.InvokeMethod, null, realMethodParams, CultureInfo.InvariantCulture);
				// TODO: currently cache expiration is set to 5 minutes. should be set according to the real data expiration setting.
				AbsoluteTime expirationTime = new AbsoluteTime(DateTime.Now.AddMinutes(5));
				_CacheManager.Add(cacheKey, result, CacheItemPriority.Normal, null, expirationTime);
			}
			return result;
		}
