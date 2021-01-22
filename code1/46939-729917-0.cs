    string sql = "INSERT INTO [ProfileGallery] ([UserId], [Title], [OriginalImage],
                  [ThumbImage]) VALUES (@userId, @title, @originalImage, @thumbImage)";
    
    string strCon = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SocialSiteConnectionString"].ConnectionString;
    SqlConnection conn = new SqlConnection(strCon);
    SqlCommand comm = new SqlCommand(sql, conn);
    comm.Parameters.Add(new SqlParameter("@userId", User.Identity.Name));
    comm.Parameters.Add(new SqlParameter("@title", Title));
    comm.Parameters.Add(new SqlParameter("@originalImage", OriginalPhoto));
    comm.Parameters.Add(new SqlParameter("@thumbImage", Thumbnail));
