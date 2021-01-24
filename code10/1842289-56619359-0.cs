csharp
using MongoDB.Entities;
namespace StackOverflow
{
    public class Program
    {
        public class User : Entity
        {
            public string Name { get; set; }
            public Post[] Posts { get; set; }
        }
        public class Post : Entity
        {
            public string Title { get; set; }
            public bool IsReadOnly { get; set; }
        }
        static void Main(string[] args)
        {
            new DB("test");
            var posts = new[] {
                new Post{ Title= "first post", IsReadOnly= true},
                new Post {Title = "second post", IsReadOnly = false}
            };
            posts.Save();
            (new User
            {
                Name = "Test User",
                Posts = posts
            }).Save();
            DB.Update<User>()
              .Match(f => f.ElemMatch(u => u.Posts, p => p.IsReadOnly == true || p.IsReadOnly == false))
              .Modify(d => d.Unset(u => u.Posts[-1].IsReadOnly))
              .Execute();
        }
    }
}
the following update command is sent to mongodb:
java
db.User.update(
    {
        "Posts": {
            "$elemMatch": {
                "$or": [
                    {
                        "IsReadOnly": true
                    },
                    {
                        "IsReadOnly": false
                    }
                ]
            }
        }
    },
    {
        "$unset": {
            "Posts.$.IsReadOnly": NumberInt("1")
        }
    }
)
