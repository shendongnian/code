    string orig = "abc   ", copy = orig;
    typeof(string).GetMethod("AppendInPlace",
        BindingFlags.NonPublic | BindingFlags.Instance,
        null, new Type[] { typeof(string), typeof(int) }, null)
        .Invoke(orig, new object[] { "def", 3 });
    Console.WriteLine(copy); // note we didn't touch "copy", so we have
                             // mutated the same reference
