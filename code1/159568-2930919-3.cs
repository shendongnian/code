    public ActionResult MyView()
    {
        IDictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();
        // retrieve data from the database
        IList<CourseData> result = RetrieveData();
        foreach (var item in result)
        {
            // [FirstName] and [LastName] combo will be used as KEY entry
            string key = item.FirstName + " " + item.LastName;
            if (dict.ContainsKey(key))
            {
                // add the class name into an existing "string" collection
                dict[key].Add( item.ClassName );
            }
            else
            {
                // instantiate a new "string" collection and add the class name.
                dict[key] = new List<string> { item.ClassName };
            }
        }
        // find out which Person has attended the most number of classes.
        int maxCourseCount = 0;
        foreach (var key in dict.Keys)
        {
            int valueCount = dict[key].Count;
            if (valueCount > maxCourseCount)
                maxCourseCount = valueCount;
        }
        MyViewModel model = new MyViewModel {
            CourseData = dict,
            MaxCourseCount = maxCourseCount
        };
        return View(model);
    }
