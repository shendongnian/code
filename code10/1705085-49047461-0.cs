    using System.IO;
    var paths = new [] { "F:\\A\\B\\C", "F:\\A\\B\\D" };
    foreach (var path in paths) {
        try {
            // Determine whether the directory exists.
            if (Directory.Exists(path)) {
                Console.WriteLine($"Skipping path '{path}' because it exists already.");
                continue;
            }
            // Try to create the directory.
            var di = Directory.CreateDirectory(path);
            Console.WriteLine($"Created path '{path}' successfully at {Directory.GetCreationTime(path)}.");
        }
        catch (Exception e) {
            Console.WriteLine($"The process failed: {e}");
        }
    }
