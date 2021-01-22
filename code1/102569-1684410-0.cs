    protected void Page_Load(object sender, EventArgs e) {
      // "zhpCtx" is a LINQ to SQL data context.
      // "TagCloud" is a Panel control.
      // Select a list of tags and a count of how often they appear in TagsPhotos
      var tagDensity = from t in zhpCtx.siteContent_Tags
                     join tp in zhpCtx.siteContent_TagsPhotos 
                       on t.TagID equals tp.TagID
                     group t by new { t.TagID, t.TagText } into g
                     where g.Count() > 0
                     orderby g.Key.TagText
                     select new { g.Key.TagID, g.Key.TagText, NumTags = g.Count() };
      if (null != tagDensity && tagDensity.Count() > 0) {
        // We have some tags, get the lowest number of counts greater than 0, and 
        // the highest to give our range.
        int? min = tagDensity.Min(t => t.NumTags);
        int? max = tagDensity.Max(t => t.NumTags);
        // Loop through each tag
        foreach (var tag in tagDensity) {
          // Create a new HyperLink control to take the user to a given tag
          // Include the tag count in the list for accessibility.
          // Could probably move it to the title attribute.
          // Build the link however suits.
          HyperLink tagLink = new HyperLink { 
                    NavigateUrl = string.Format("Photos.aspx?TagID={0}", tag.TagID),
                    Text = string.Format("{0} ({1})", tag.TagText, tag.NumTags) };
          // Adjust the font-size of the tag link - calling getPercentage.
          // This will adjust the size based on the baseline font size for the 
          // container
          tagLink.Style.Add("font-size", 
            string.Format("{0}%", 
                           getPercentageSize((int)max, (int)min, tag.NumTags)));
        
          // Add the HyperLink to the Panel.
          TagCloud.Controls.Add(tagLink);
          // Add a LiteralControl with a comma and a space.
          TagCloud.Controls.Add(new LiteralControl(", "));
        }
        // Remove the last separator control from the Panel.
        TagCloud.Controls.RemoveAt(TagCloud.Controls.Count - 1);
      } else {
        // Hide the tag cloud panel
        TagCloud.Visible = false;
      }
    }
    private int getPercentageSize(int max, int min, int score) {
        // Ensure we've got a sensible number
        if (min < 1) {
            min = 1;
        }
        double spread = max - min;
        if (spread == 0) {
            spread = 1;
        }
        // Setup sensible bounds for the font sizes
        int minSize = 80;
        int maxSize = 200;
        // Step ensures that our least used keyword is 80% and our 
        // most used is 200%
        double step = (maxSize - minSize) / spread;
        
        return (int)(minSize + ((score - min) * step));
    }
