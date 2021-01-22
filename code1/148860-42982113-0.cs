    public static void ReleaseComObjects(params object[] objects)
        {
            if (objects == null)
            {
                return;
            }
            foreach (var obj in objects)
            {
                if (obj != null)
                {
                    try
                    {
                        Marshal.FinalReleaseComObject(obj);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
            }
        }
