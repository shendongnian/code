    var query = from story in m_BackLoggerEntities.Stories
                where story.StoryId == id
                select new {
                              story,
                              Tasks = from task in story.Tasks
                                      where task.Active
                                      select task
                           };
    var stories = query
       .AsEnumerable()
       .Select(x => x.Story);
