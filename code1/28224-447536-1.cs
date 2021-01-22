      [GuidAttribute("D26278EA-A7D0-4580-A48F-353D1E455E50"),
      ProgIdAttribute("My PROGID"),
      ComVisible(true),
      Serializable]
      public class MyCOMClass : IAlreadyRegisteredCOMInterface
      {
        public void MyMethod()
        {
        }
    
        [ComRegisterFunction]
        public static void RegisterFunction(Type t)
        {
          AttributeCollection attributes = TypeDescriptor.GetAttributes(t);
          ProgIdAttribute ProgIdAttr = attributes[typeof(ProgIdAttribute)] as ProgIdAttribute;
    
          string ProgId = ProgIdAttr != null ? ProgIdAttr.Value : t.FullName;
    
          GuidAttribute GUIDAttr = attributes[typeof(GuidAttribute)] as GuidAttribute;
          string GUID = "{" + GUIDAttr.Value + "}";
    
          RegistryKey localServer32 = Registry.ClassesRoot.CreateSubKey(String.Format("CLSID\\{0}\\LocalServer32", GUID));
          localServer32.SetValue(null, t.Module.FullyQualifiedName);
    
          RegistryKey CLSIDProgID = Registry.ClassesRoot.CreateSubKey(String.Format("CLSID\\{0}\\ProgId", GUID));
          CLSIDProgID.SetValue(null, ProgId);
    
          RegistryKey ProgIDCLSID = Registry.ClassesRoot.CreateSubKey(String.Format("CLSID\\{0}", ProgId));
          ProgIDCLSID.SetValue(null, GUID);
   
          //Registry.ClassesRoot.CreateSubKey(String.Format("CLSID\\{0}\\Implemented Categories\\{{63D5F432-CFE4-11D1-B2C8-0060083BA1FB}}", GUID));
          //Registry.ClassesRoot.CreateSubKey(String.Format("CLSID\\{0}\\Implemented Categories\\{{63D5F430-CFE4-11d1-B2C8-0060083BA1FB}}", GUID));
          //Registry.ClassesRoot.CreateSubKey(String.Format("CLSID\\{0}\\Implemented Categories\\{{62C8FE65-4EBB-45e7-B440-6E39B2CDBF29}}", GUID));
        }
    
        [ComUnregisterFunction]
        public static void UnregisterFunction(Type t)
        {
          AttributeCollection attributes = TypeDescriptor.GetAttributes(t);
          ProgIdAttribute ProgIdAttr = attributes[typeof(ProgIdAttribute)] as ProgIdAttribute;
    
          string ProgId = ProgIdAttr != null ? ProgIdAttr.Value : t.FullName;
    
          Registry.ClassesRoot.DeleteSubKeyTree("CLSID\\{" + t.GUID + "}");
          Registry.ClassesRoot.DeleteSubKeyTree("CLSID\\" + ProgId);
        }
    
      }
