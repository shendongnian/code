	class Question : Post
	{
		public Question()
		{
			//...
		}
		public Question(Post p)
		{
			// copy stuff to 'this'
		}
		public static implicit operator Question(Post p)
		{
			Question q = new Question(p);
			return q;
		}
	}
