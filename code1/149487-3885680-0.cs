	/// <summary>
	/// Occurs when the post is being served to the output stream.
	/// </summary>
	public static event EventHandler<ServingEventArgs> Serving;
	/// <summary>
	/// Raises the event in a safe way
	/// </summary>
	public static void OnServing(Post post, ServingEventArgs arg)
	{
		if (Serving != null)
		{
			Serving(post, arg);
		}
	}
