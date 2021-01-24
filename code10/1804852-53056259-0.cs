    // Controller action
    var levels = logsData.GetLogLevels().Select(x => new SelectListItem { Text = x, Value = x }).ToList();
    // Model class
    public class LevelsListViewModel
    {
        public List<SelectListItem> Levels { get; set; }
    }
