      Type GetItemType(object someCollection)
      {
        var type = someCollection.GetType();
        var ienum = type.GetInterface(typeof(IEnumerable<>).Name);
        return ienum != null
          ? ienum.GetGenericArguments()[0]
          : null;
      }
