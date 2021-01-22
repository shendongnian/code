      IEnumerable<IMetaDataScope> allMetaDataScopes = ScopeManager.All;
      foreach (IMetaDataScope scope in allMetaDataScopes)
      {
        IAssemblyInfo assembly = scope.Assembly;
        if (assembly != null)
        {
          ITypeInfo[] types = assembly.GetTypes();
          for (int i = 0; i < types.Length; i++)
          {
            ITypeInfo typeInfo = types[i];
            if (typeInfo == null)
              continue;
            // TODO: ...
          }
        }
      }
