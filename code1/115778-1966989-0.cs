    private List<System.Linq.IQueryable<ArticleComment>> _Comments;
    public List<System.Linq.IQueryable<ArticleComment>> Comments
    {
        get
        {
            if (_Comments == null)
                _Comments = new List<IQueryable<ArticleComment>>();
            return _Comments;
        }
        set
        {
            _Comments = value;
        }
    }
