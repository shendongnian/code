    public async Task UpdateDesiredProperties(string deviceId)
    {
    	var twin = await _registryManager.GetTwinAsync(deviceId);
    
    	var patch =
    		@"{
    		properties: {
    			desired: {
    			  customKey: 'customValue'
    			}
    		}
    	}";
    
    	await _registryManager.UpdateTwinAsync(twin.DeviceId, patch, twin.ETag);
    }
