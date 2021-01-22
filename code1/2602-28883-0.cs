<br>
var TopNavs = from n in ds.NavigationTopLevels
                          select new TopNav
                          {
                              NavigateUrl = String.Format("{0}/{1}", tmpURL, n.id),
                              Text = n.Text,
                              id = n.id,
                              SubItems = new List&lt;SubNav&gt;(
                                  from si in ds.NavigationBottomLevels
                                  where si.parentID == n.id
                                  select new SubNav
                                  {
                                      id = si.id,
                                      level = si.NavLevel,
                                      NavigateUrl = String.Format("{0}/{1}/{2}", tmpURL, n.id, si.id),
                                      parentID = si.parentID,
                                      Text = si.Text
                                  }
                                )
                          };
 List&lt;TopNav&gt; TopNavigation = TopNavs.ToList(); 
<br>
