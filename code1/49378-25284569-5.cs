    private static string GetMvcVersionString() {
      // DevDiv 216459:
      // This code originally used Assembly.GetName(), but that requires FileIOPermission, which isn't granted in
      // medium trust. However, Assembly.FullName *is* accessible in medium trust.
      return new AssemblyName(typeof(MvcHttpHandler).Assembly.FullName).Version.ToString(2);
    }
