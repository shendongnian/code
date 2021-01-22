    private List<ArticleComment> _Comments;
    public List<ArticleComment> Comments
    {
        get
        {
            if (_Comments == null)
                _Comments = new List<ArticleComment>();
            return _Comments;
        }
        set
        {
            _Comments = value;
        }
    }
