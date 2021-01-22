    public static IEnumerable<Notice> FirstTypeNotices
    {
    	get
    	{
    		return Notices.Where(n => n.Type == NoticeType.FirstType);
    	}
    }
