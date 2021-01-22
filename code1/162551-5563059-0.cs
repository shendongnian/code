    public static IEnumerable<ManagementObject> WithDisposal(
                        this ManagementObjectCollection list)
    {
        using (list)
        {
            foreach (var obj in list)
            {
                using (obj)
                {
                    yield return obj;
                }
            }
        }
     }
