	public Diary() {
		this.Like = defaultLike;
		this.Dislike = defaultDislike;
	}
	public Diary(string title, string diary): this()
	{
		this.Title = title;
		this.DiaryText = diary;
	}
	public Diary(string title, string diary, string category): this(title, diary) {
		this.Category = category;
	}
	public Diary(int id, string title, string diary, string category)
		: this(title, diary, category)
	{
		this.DiaryID = id;
	}
