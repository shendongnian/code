    private static void DeleteRecursivelyWithMagicDust(string destinationDir) {
        const int magicDust = 10;
        for (var gnomes = 1; gnomes <= magicDust; gnomes++) {
            try {
                Directory.Delete(destinationDir, true);
            } catch (DirectoryNotFoundException) {
                return;  // good!
            } catch (IOException) { // System.IO.IOException: The directory is not empty
                System.Diagnostics.Debug.WriteLine("Gnomes prevent deletion of {0}! Applying magic dust, attempt #{1}.", destinationDir, gnomes);
                // see http://stackoverflow.com/questions/329355/cannot-delete-directory-with-directory-deletepath-true for more magic
                Thread.Sleep(50);
                continue;
            }
            return;
        }
    }
