    var version   = Assembly.GetExecutingAssembly().GetName().Version()
    var intVesion = version.Major * 100000000 + 
                    version.Minor * 1000000 + 
                    version.Build * 100 + 
                    version.Revision
