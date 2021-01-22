    AssemblyName[] asmNames = asm.GetReferencedAssemblies();
    foreach (AssemblyName nm in asmNames)
    {
        Console.WriteLine(nm.FullName);
    }
    private bool GetReferenceAssembly(Assembly asm)
          {
                   try
                   {
                       AssemblyName[] list = asm.GetReferencedAssemblies();
                       if (list.Length > 0)
                       {
                           AssemblyInformation info = null;
                           _lstReferences = new List();
                            for (int i = 0; i < list.Length; i++)
                            {
                                info = new AssemblyInformation();
                                info.Name = list[i].Name;
                                info.Version = list[i].Version.ToString();
                                info.FullName = list[i].ToString();
        
                                this._lstReferences.Add(info);
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        this._errMsg = err.Message;
                        return false;
                    }
        
                    return true;
           }
