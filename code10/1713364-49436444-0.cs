     public class I18nErrorMessage
    {
        public string i18nKey { get; set; }
        public List<object> parameters { get; set; }
    }
    public class Customfield10502
    {
        public string errorMessage { get; set; }
        public I18nErrorMessage i18nErrorMessage { get; set; }
    }
    public class I18nErrorMessage2
    {
        public string i18nKey { get; set; }
        public List<object> parameters { get; set; }
    }
    public class Customfield10503
    {
        public string errorMessage { get; set; }
        public I18nErrorMessage2 i18nErrorMessage { get; set; }
    }
    public class Color
    {
        public string key { get; set; }
    }
    public class Epic
    {
        public int id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public Color color { get; set; }
        public bool done { get; set; }
    }
    public class Priority
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }
    public class I18nErrorMessage3
    {
        public string i18nKey { get; set; }
        public List<object> parameters { get; set; }
    }
    public class Customfield10616
    {
        public string errorMessage { get; set; }
        public I18nErrorMessage3 i18nErrorMessage { get; set; }
    }
    public class AvatarUrls
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }
    public class Assignee
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }
    public class StatusCategory
    {
        public string self { get; set; }
        public int id { get; set; }
        public string key { get; set; }
        public string colorName { get; set; }
        public string name { get; set; }
    }
    public class Status
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public StatusCategory statusCategory { get; set; }
    }
    public class AvatarUrls2
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }
    public class Creator
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls2 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }
    public class AvatarUrls3
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }
    public class Reporter
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls3 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }
    public class Aggregateprogress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }
    public class Customfield10711
    {
        public string self { get; set; }
        public string value { get; set; }
        public string id { get; set; }
    }
    public class AvatarUrls4
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }
    public class Customfield10712
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls4 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }
    public class ClosedSprint
    {
        public int id { get; set; }
        public string self { get; set; }
        public string state { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime completeDate { get; set; }
        public int originBoardId { get; set; }
        public string goal { get; set; }
    }
    public class Progress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }
    public class Votes
    {
        public string self { get; set; }
        public int votes { get; set; }
        public bool hasVoted { get; set; }
    }
    public class Worklog
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<object> worklogs { get; set; }
    }
    public class Issuetype
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
        public int avatarId { get; set; }
    }
    public class Sprint
    {
        public int id { get; set; }
        public string self { get; set; }
        public string state { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int originBoardId { get; set; }
        public string goal { get; set; }
    }
    public class AvatarUrls5
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }
    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string projectTypeKey { get; set; }
        public AvatarUrls5 avatarUrls { get; set; }
    }
    public class Watches
    {
        public string self { get; set; }
        public int watchCount { get; set; }
        public bool isWatching { get; set; }
    }
    public class Timetracking
    {
    }
    public class I18nErrorMessage4
    {
        public string i18nKey { get; set; }
        public List<object> parameters { get; set; }
    }
    public class Customfield10400
    {
        public string errorMessage { get; set; }
        public I18nErrorMessage4 i18nErrorMessage { get; set; }
    }
    public class Comment
    {
        public List<object> comments { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public int startAt { get; set; }
    }
    public class StatusCategory2
    {
        public string self { get; set; }
        public int id { get; set; }
        public string key { get; set; }
        public string colorName { get; set; }
        public string name { get; set; }
    }
    public class Status2
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public StatusCategory2 statusCategory { get; set; }
    }
    public class Priority2
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }
    public class Issuetype2
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
        public int avatarId { get; set; }
    }
    public class Fields2
    {
        public string summary { get; set; }
        public Status2 status { get; set; }
        public Priority2 priority { get; set; }
        public Issuetype2 issuetype { get; set; }
    }
    public class Parent
    {
        public string id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public Fields2 fields { get; set; }
    }
    public class Fields
    {
        public List<object> fixVersions { get; set; }
        public object customfield_10110 { get; set; }
        public object customfield_10111 { get; set; }
        public object resolution { get; set; }
        public object customfield_10112 { get; set; }
        public List<string> customfield_10113 { get; set; }
        public string customfield_10114 { get; set; }
        public object customfield_10104 { get; set; }
        public object customfield_10500 { get; set; }
        public object customfield_10501 { get; set; }
        public object customfield_10105 { get; set; }
        public object customfield_10106 { get; set; }
        public Customfield10502 customfield_10502 { get; set; }
        public Customfield10503 customfield_10503 { get; set; }
        public object customfield_10107 { get; set; }
        public object customfield_10108 { get; set; }
        public object customfield_10109 { get; set; }
        public object lastViewed { get; set; }
        public Epic epic { get; set; }
        public Priority priority { get; set; }
        public DateTime? customfield_10100 { get; set; }
        public object customfield_10101 { get; set; }
        public object customfield_10102 { get; set; }
        public List<object> labels { get; set; }
        public object customfield_10103 { get; set; }
        public object customfield_10731 { get; set; }
        public object customfield_10610 { get; set; }
        public object customfield_10611 { get; set; }
        public object customfield_10612 { get; set; }
        public string customfield_10733 { get; set; }
        public object customfield_10613 { get; set; }
        public object timeestimate { get; set; }
        public object customfield_10614 { get; set; }
        public object aggregatetimeoriginalestimate { get; set; }
        public DateTime? customfield_10735 { get; set; }
        public List<object> versions { get; set; }
        public object customfield_10615 { get; set; }
        public Customfield10616 customfield_10616 { get; set; }
        public object customfield_10617 { get; set; }
        public List<object> issuelinks { get; set; }
        public Assignee assignee { get; set; }
        public Status status { get; set; }
        public List<object> components { get; set; }
        public object customfield_10730 { get; set; }
        public object customfield_10600 { get; set; }
        public object customfield_10601 { get; set; }
        public object customfield_10602 { get; set; }
        public object customfield_10603 { get; set; }
        public object aggregatetimeestimate { get; set; }
        public object customfield_10604 { get; set; }
        public object customfield_10605 { get; set; }
        public object customfield_10606 { get; set; }
        public object customfield_10727 { get; set; }
        public object customfield_10728 { get; set; }
        public object customfield_10607 { get; set; }
        public object customfield_10608 { get; set; }
        public object customfield_10729 { get; set; }
        public object customfield_10609 { get; set; }
        public Creator creator { get; set; }
        public List<object> subtasks { get; set; }
        public Reporter reporter { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public Customfield10711 customfield_10711 { get; set; }
        public Customfield10712 customfield_10712 { get; set; }
        public List<ClosedSprint> closedSprints { get; set; }
        public Progress progress { get; set; }
        public Votes votes { get; set; }
        public Worklog worklog { get; set; }
        public Issuetype issuetype { get; set; }
        public object timespent { get; set; }
        public Sprint sprint { get; set; }
        public Project project { get; set; }
        public object aggregatetimespent { get; set; }
        public object resolutiondate { get; set; }
        public int workratio { get; set; }
        public Watches watches { get; set; }
        public DateTime created { get; set; }
        public object customfield_10300 { get; set; }
        public object customfield_10301 { get; set; }
        public DateTime updated { get; set; }
        public object timeoriginalestimate { get; set; }
        public string description { get; set; }
        public Timetracking timetracking { get; set; }
        public List<object> customfield_10401 { get; set; }
        public object customfield_10402 { get; set; }
        public string customfield_10006 { get; set; }
        public object customfield_10403 { get; set; }
        public object security { get; set; }
        public object customfield_10007 { get; set; }
        public List<object> attachment { get; set; }
        public bool flagged { get; set; }
        public string summary { get; set; }
        public string customfield_10000 { get; set; }
        public object customfield_10001 { get; set; }
        public object customfield_10002 { get; set; }
        public Customfield10400 customfield_10400 { get; set; }
        public object environment { get; set; }
        public object duedate { get; set; }
        public Comment comment { get; set; }
        public string customfield_10710 { get; set; }
        public Parent parent { get; set; }
    }
    public class Issue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }
    }
    public class RootObject
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Issue> issues { get; set; }
    }
