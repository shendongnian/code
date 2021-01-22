    RegistryKey reg;
    
                try
                {
                    reg = Registry.CurrentUser.OpenSubKey(BaseKey,true); //<--over here!
                    reg.DeleteSubKey("{" + Item.Guid.ToString() + "}");
                }
                catch
                {
                    return false;
                }
