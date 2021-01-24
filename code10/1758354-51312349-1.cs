    using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
    using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
    using Microsoft.VisualStudio.Services.Common;
    using Microsoft.VisualStudio.Services;
    using Microsoft.VisualStudio.Services.WebApi;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.Services.Client;
    namespace GetFTTaskCompleteForDates
    {
        class Program
        {
            public class FTTaskComleted
            {
                public int FTID = 0;
                public int TaskID = 0;
                public int CompletedOnDate = 0;
                public int CompletedFieldValue = 0;
                public DateTime ReportDT;
            }
            static public class WIQLS
            {
                static public string ChangedTasksFromDate = "SELECT [System.Id] FROM WorkItems WHERE [System.TeamProject] = '{0}'  AND  [System.WorkItemType] = 'Task'  AND  [System.ChangedDate] >= '{1}-{2}-{3}T00:00:00.0000000' ORDER BY [System.Id]";
                static public string GetTopParentFeature = "SELECT [System.Id] FROM WorkItemLinks WHERE ([Source].[System.TeamProject] = '{0}'  AND  [Source].[System.WorkItemType] = 'Feature') And ([System.Links.LinkType] = 'System.LinkTypes.Hierarchy-Forward') And ([Target].[System.Id] = {1}) ORDER BY [System.Id] mode(Recursive,ReturnMatchingChildren)";
            }
            static string ServiceUrl = "http://tfs-srv:8080/tfs/DefaultCollection";
            static string TeamProject = "VSTSAgile";
            static WorkItemTrackingHttpClient WiClient = null; 
            static VssConnection ServiceConnection = null;
            static string CompletedWorkFieldRef = "Microsoft.VSTS.Scheduling.CompletedWork";
            static string ChangedDateFieldRef = "System.ChangedDate";
            static void Main(string[] args)
            {
                DateTime _startDate = new DateTime(2018, 06, 19);
                DateTime _finishDate = DateTime.Today;  // set to DateTime.MinValue if only one date
                //DateTime _finishDate = DateTime.MinValue;
                List<FTTaskComleted> _lstReport = new List<FTTaskComleted>();
                if (!ConnectToService()) return;
                Dictionary<int, int> _dctTasksFeatures = GetTaskAndFeatures(_startDate);
                if (_dctTasksFeatures.Keys.Count > 0) FillReportList(_dctTasksFeatures, _lstReport, _startDate, _finishDate);
                foreach (FTTaskComleted _item in _lstReport)
                    Console.WriteLine("DATE:{0} -- FT:{1} -- TSK:{2} -- HRS -- {3}", _item.ReportDT.ToShortDateString(), _item.FTID, _item.TaskID, _item.CompletedOnDate);
            }
            //Fill list with hours for each date and task
            private static void FillReportList(Dictionary<int, int> pDctTasksFT, List<FTTaskComleted> pLstReport, DateTime pStartDate, DateTime pFinishtDate)
            {
                foreach (int _taskId in pDctTasksFT.Keys)
                {
                    List<WorkItem> _revs = WiClient.GetRevisionsAsync(_taskId).Result;
                    DateTime _lastDate = DateTime.MinValue; //last processed date for revisions of work item
                    int _lastHours = int.MinValue; //last processed value of compteted work for revisions of work item
                    foreach (WorkItem _rev in _revs)
                    {                    
                        if (!_rev.Fields.Keys.Contains(CompletedWorkFieldRef) || !_rev.Fields.Keys.Contains(ChangedDateFieldRef)) continue;
                        DateTime _changedDate;
                        if (!DateTime.TryParse(_rev.Fields[ChangedDateFieldRef].ToString(), out _changedDate)) continue;
                        bool _inscope = false;
                        // calculate hours based on previous revision
                        int _completedValue, _completedDiff;
                        if (!int.TryParse(_rev.Fields[CompletedWorkFieldRef].ToString(), out _completedValue)) continue;
                        if (_lastHours == int.MinValue) _completedDiff = _completedValue;
                        else _completedDiff = _completedValue - _lastHours;
                        _lastHours = _completedValue;
                        // check for date of revision between needed dates
                        if (pFinishtDate == DateTime.MinValue) { if (_changedDate.Date == pStartDate.Date) _inscope = true; }
                        else if (_changedDate.Date >= pStartDate.Date && _changedDate.Date <= pFinishtDate.Date) _inscope = true;
                        if (_inscope && _completedDiff != 0)
                        {
                            if (_lastDate.Date == _changedDate.Date && pLstReport.Count > 0)
                            {
                                //update existing item if several changes in one day
                                pLstReport[pLstReport.Count - 1].CompletedOnDate += _completedDiff;
                                pLstReport[pLstReport.Count - 1].CompletedFieldValue = _completedValue;
                            }
                            else // add new report item
                                pLstReport.Add(
                                    new FTTaskComleted
                                    {
                                        FTID = pDctTasksFT[_taskId],
                                        TaskID = _taskId, ReportDT = _changedDate,
                                        CompletedOnDate = _completedDiff,
                                        CompletedFieldValue = _completedValue }
                                    );
                            _lastDate = _changedDate;
                        }
                    }
                }
            }
            //find all tasks changed after start date. beacouse we can not select revisions beetwen dates.
            static Dictionary<int, int> GetTaskAndFeatures(DateTime pStartDate)
            {
                Dictionary<int, int> _taskft = new Dictionary<int, int>();
                List<int> _ids = GetTasksIdsForPeriod(pStartDate);
                if (_ids.Count > 0)
                {
                    foreach(int _wiId in _ids)
                        if (!AddFeaturesToTask(_wiId, _taskft)) break;
                }
                return _taskft;
            }
            //find feature id for task and exclude tasks without parent features
            static bool AddFeaturesToTask(int pId, Dictionary<int, int> pWiDict)
            {
                try
                {
                    Wiql _wiql = new Wiql();
                    _wiql.Query = String.Format(WIQLS.GetTopParentFeature, TeamProject, pId);
                    WorkItemQueryResult _res = WiClient.QueryByWiqlAsync(_wiql).Result;
                    if (_res.WorkItemRelations.Count() > 1)
                        pWiDict.Add(pId, _res.WorkItemRelations.ElementAt(0).Target.Id); //first is a top parent
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Query problem:");
                    Console.WriteLine(ex.Message);
                    return false;
                }
                return true;
            }
            static public bool ConnectToService()
            {
                try
                {
                    VssCredentials creds = new VssClientCredentials();
                    creds.Storage = new VssClientCredentialStorage();
                    ServiceConnection = new VssConnection(new Uri(ServiceUrl), creds);
                    ServiceConnection.ConnectAsync().Wait();
                    WiClient = ServiceConnection.GetClient<WorkItemTrackingHttpClient>();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Connection problem:");
                    Console.WriteLine(ex.Message);
                    return false;
                }
                return true;
            }
            static public List<int> GetTasksIdsForPeriod(DateTime pStart)
            {
                List<int> _ids = new List<int>();
                try
                {
                    Wiql _wiql = new Wiql();
                    _wiql.Query = String.Format(WIQLS.ChangedTasksFromDate, TeamProject, pStart.Year, pStart.Month, pStart.Day);
                    WorkItemQueryResult _res = WiClient.QueryByWiqlAsync(_wiql).Result;
                    if (_res.WorkItems.Count() > 0)
                        foreach (WorkItemReference _wi in _res.WorkItems) _ids.Add(_wi.Id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Query problem:");
                    Console.WriteLine(ex.Message);
                }
                return _ids;
            }
        }
    }
