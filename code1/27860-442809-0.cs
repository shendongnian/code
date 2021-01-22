    class Program
        {
            static void Main(string[] args)
            {
                CommentCollection collection=new CommentCollection();
                Comment c1=new Comment("Blah",1,0,collection);
                Comment c2=new Comment("Blah blah",2,1,collection);
                Comment c3=new Comment("Blah blah", 3, 2, collection);
                Console.WriteLine(collection);
            }
        }
        [DebuggerDisplay("{id}-{parentId}: {text}")]
        class Comment:IEnumerable<Comment>
        {
            private readonly CommentCollection collection;
            private readonly int parentId;
    
            public Comment(string text, int id, int parentId, CommentCollection collection)
            {
                Id = id;
                this.parentId = parentId;
                collection.Add(this);
                this.collection = collection;
                this.text = text;
            }
            public Comment Parent
            {
                get
                {
                    if (parent == null)
                    {
                        parent = parentId == 0 ? null : collection[parentId];
                    }
                    return parent;
                }
            }
    
            private Comment parent;
            private readonly string text;
            public int Id{ get; private set;}
            public IEnumerator<Comment> GetEnumerator()
            {
                return collection.Where(c => c.Parent == this).GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public int Level
            {
                get { return Parent == null ? 0 : Parent.Level + 1; }
            }
            public override string ToString()
            {
                return Parent == null ? text : Parent + " > " + text;
            }
            public string ToString(bool tree)
            {
                if (!tree)
                {
                    return ToString();
                }
                else
                {
                    StringBuilder output = new StringBuilder();
                    output.AppendLine(new string(' ', Level) + ToString(false));
                    foreach (Comment comment in this)
                    {
                        output.AppendLine(comment.ToString(true));
                    }
                    return output.ToString();
                }
            }
        }
        class CommentCollection:IEnumerable<Comment>
        {
            public void Add(Comment comment)
            {
                comments.Add(comment.Id,comment);
            }
            public Comment this[int id]
            {
                get { return comments[id]; }
            }
            private readonly Dictionary<int,Comment> comments=new Dictionary<int, Comment>();
    
            public IEnumerator<Comment> GetEnumerator()
            {
                return comments.Select(p => p.Value).GetEnumerator();
            }
    
            public IEnumerable<Comment> GetTopLevel()
            {
                return comments.Where(c => c.Value.Parent == null).
                    Select(c => c.Value);
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public override string ToString()
            {
                StringBuilder output=new StringBuilder();
                foreach (Comment comment in GetTopLevel())
                {
                    output.AppendLine(comment.ToString(true));
                }
                return output.ToString();
            }
        }
