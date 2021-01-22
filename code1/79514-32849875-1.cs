    private static void ProcessOnDeserilize(object _result) {
      var type = _result != null ? _result.GetType() : null;
      var methods = type != null ? type.GetMethods().Where(_ => _.GetCustomAttributes(true).Any(_m => _m is OnDeserializedAttribute)) : null;
      if (methods != null) {
        foreach (var method in methods) {
          method.Invoke(_result, null);
        }
      }
    }
