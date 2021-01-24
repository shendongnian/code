    //Linq Query
    var ideasQuery = from b in db.StarLive_StarIBox_Ideas.Where(b => b.UserId == userid)
                             select new IdeasDTO()
                             {
                                 IdeaId = b.IdeaId,
                                 Idea = b.Idea,
                                 UserName = b.StarLive_Sys_Users.cLogName,
                                 DatePosted = b.DatePosted.ToString(),
                                 Problem = b.StarLive_StarIBox_Problems.Problems,
                                 Department = b.StarLive_Sys_Users.nDeptID.ToString(),
                                 LikeId=b.StarLive_StarIBox_Likes.Where
                                 (l=>l.IdeaId==b.IdeaId && l.LikedBy==b.UserId).FirstOrDefault().LikeID
    
    
                        };
