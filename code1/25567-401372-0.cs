    if(Directory.Exists(yourPath)) {
      var entries = yourPath.Split(@"\/", StringSplitOptions.RemoveEmptyEntries);
    }
    else if(File.Exists(yourPath)) {
      var entries = Path.GetDirectoryName(yourPath).Split(
                        @"\/", StringSplitOptions.RemoveEmptyEntries);
    }
    else {
      // error handling
    }
