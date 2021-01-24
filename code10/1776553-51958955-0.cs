    //Note: Ignoring newlines because they are believed to be insignificant. No <pre> etc expected.
    // This allows newlines to vary across systems and across time.
    Func<String, List<String>> splitByLineAndRemoveEmpty = 
        input => Regex.Split(input, @"\r|\n").Where(line => !String.IsNullOrEmpty(line)).ToList();
    CollectionAssert.AreEqual(
        splitByLineAndRemoveEmpty(expected), 
        splitByLineAndRemoveEmpty(File.ReadAllText(path)));
