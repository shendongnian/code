    Queue<DirectoryEntry> queue = new Queue<DirectoryEntry>();
    DirectoryEntry root = new DirectoryEntry(someDN);
	queue.Add(root);
	
	while (queue.Any())
	{
		using (DirectoryEntry de = queue.Dequeue())
		{
			// Do some work here against the directory entry
			if (de.Children != null)
			{
				foreach (DirectoryEntry child in de.Children)
				{
					queue.Enqueue(child);
				}
			}
		}
	}
