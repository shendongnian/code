        if (ModelState.IsValid) {
            try {
                Author author = _authorRepository.GetById(id);
                var postIds = author.Posts.Select(post => post.Id);
                // Loop through posts and remove
                foreach (var postId in postIds) {
                    var post = _postRepository.GetById(postIds);
                    _postRepository.Remove(post);
                }
                // Done with posts
                _authorRepository.Remove(author);
                _authorRepository.SaveChanges();
                TempData["Success"] = $"{author.Firstname} {author.Lastname} has been successfully deleted!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) {
                ModelState.AddModelError("", ex.Message);
            }
