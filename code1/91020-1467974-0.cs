    public static IEnumerable<RemoteDevice> MakeEnumerable(this RemoteDevices devices) {
      for ( var i = 0; i < devices.Count; i++ ){
        yield return devices[i];
      }
    }
