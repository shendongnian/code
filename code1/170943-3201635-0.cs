	public static bool Copy(string Source, string destination)
	{
		try {
			string[] Files = null;
			if (destination[destination.Length - 1] != Path.DirectorySeparatorChar) {
				destination += Path.DirectorySeparatorChar;
			}
			if (!Directory.Exists(destination)) {
				Directory.CreateDirectory(destination);
			}
			Files = Directory.GetFileSystemEntries(Source);
			foreach (string Element in Files) {
				// Sub directories
				if (Directory.Exists(Element)) {
					copyDirectory(Element, destination + Path.GetFileName(Element));
				} else {
					// Files in directory
					File.Copy(Element, destination + Path.GetFileName(Element), true);
				}
			}
		} catch (Exception ex) {
			return false;
		}
		return true;
	}
	private static void copyDirectory(string Source, string destination)
	{
		string[] Files = null;
		if (destination[destination.Length - 1] != Path.DirectorySeparatorChar) {
			destination += Path.DirectorySeparatorChar;
		}
		if (!Directory.Exists(destination)) {
			Directory.CreateDirectory(destination);
		}
		Files = Directory.GetFileSystemEntries(Source);
		foreach (string Element in Files) {
			// Sub directories
			if (Directory.Exists(Element)) {
				copyDirectory(Element, destination + Path.GetFileName(Element));
			} else {
				// Files in directory
				File.Copy(Element, destination + Path.GetFileName(Element), true);
			}
		}
	}
}
