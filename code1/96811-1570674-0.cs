    public string PostsAsSlides(PostCollection posts, int postsPerSlide) {
       StringBuilder builder = new StringBuilder();
       int postCount = 0;
       foreach (Post post in posts) {
          postCount++;
          string cssClass;
          if (postCount == 1) {
             builder.Append("<div class=\"slide\">\n");
             cssClass = "slide-block first";
          } else if (postCount == postsPerSlide) {
             cssClass = "slide-block last";
             postCount = 0;
          } else {
             cssClass = "slide-block";
          }
          builder.Append("<div class=\"").Append(cssClass).Append("\">\n")
             .Append("<a href=\"").Append(post.Custom("Large Image"))
             .Append("\" rel=\"prettyPhoto[gallery]\" title=\"")
             .Append(post.MetaDescription).Append("\"><img src=\"")
             .Append(post.ImageUrl).Append("\" alt=\"").Append(post.Title)
             .Append("\" /></a>\n")
             .Append("<a class=\"button-launch-website\" href=\"")
             .Append(post.Custom("Website Url"))
             .Append("\" target=\"_blank\">Launch Website</a>\n")
             .Append("</div><!--.slide-block-->\n");
          if (postCount == 0) {
             builder.Append("</div><!--.slide-->\n");
          }
       }
       return builder.ToString();
    }
