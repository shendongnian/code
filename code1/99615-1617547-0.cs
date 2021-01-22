      catch (Win32Exception e)
                {
                    if(e.NativeErrorCode == ERROR_FILE_NOT_FOUND)
                    {
                        Console.WriteLine(e.Message + ". Check the path.");
                    } 
