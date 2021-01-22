	 public VideoDTO AddCommentToVideo(VideoDTO pVideo, CommentDTO pComment)
	        {
	            Video video = context.Videos.Where(v => v.VideoId == 
			pVideo.VideoId).FirstOrDefault();
	            User user = context.Users.Where(u => u.UserId == 
			pComment.User.UserId).FirstOrDefault();
	            Comment comment = new Comment();
	            comment.CommentText = pComment.CommentText;
	            comment.User = user;
	            comment.Videos.Add(video);
	            context.AddToComments(comment);
	            context.SaveChanges();
	            return pVideo;
	        }
