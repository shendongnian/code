    var query = from p in _repository.GetPosts()
                        where p.PostId == id
                        orderby {
                            Comment comment = p.Comments.FirstOrDefault();
                            return comment == null ? DateTime.MinValue : comment.Created;
                        }
                        select p;
