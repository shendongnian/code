    private static void ProcessOnDeserialize(object _result) {
      var type = _result != null ? _result.GetType() : null;
      var methods = type != null ? type.GetMethods().Where(_ => _.GetCustomAttributes(true).Any(_m => _m is OnDeserializedAttribute)) : null;
      if (methods != null) {
        foreach (var mi in methods) {
          mi.Invoke(_result, null);
        }
      }
      var properties = type != null ? type.GetProperties().Where(_ => _.GetCustomAttributes(true).Any(_m => _m is XmlElementAttribute || _m is XmlAttributeAttribute)) : null;
      if (properties != null) {
        foreach (var prop in properties) {
          var obj = prop.GetValue(_result, null);
          var enumeration = obj as IEnumerable;
          if (obj is IEnumerable) {
            foreach (var item in enumeration) {
              ProcessOnDeserialize(item);
            }
          } else {
            ProcessOnDeserialize(obj);
          }
        }
      }
    }
