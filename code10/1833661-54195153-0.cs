    if (Build.VERSION.SdkInt >= Build.VERSION_CODES.M)
                {
                    if (this.CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != Permission.Granted)
                    {
                        RequestPermissions(new String[] { Manifest.Permission.AccessCoarseLocation }, 1);
                    }
                }
