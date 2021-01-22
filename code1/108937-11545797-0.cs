        public Dairy() {
            this.Like = defaultLike;
            this.Dislike = defaultDislike;
        }
        public Dairy(string title, string dairy): this()
        {
            this.Title = title;
            this.DairyText = dairy;
        }
        public Dairy(string title, string dairy, string category): this(title, dairy) {
            this.Category = category;
        }
        public Dairy(int id, string title, string dairy, string category)
            : this(title, dairy, category)
        {
            this.DairyID = id;
        }
