         var version = SemVersion.Parse("1.2.45-alpha-beta+nightly.23.43-bla");
        Console.WriteLine(version);
        Console.WriteLine( version.Major); //1
        Console.WriteLine( version.Minor); //2
        Console.WriteLine( version.Patch); //45
        Console.WriteLine(version.Prerelease); //alpha-beta
        Console.WriteLine(version.Build); //nightly.23.43
