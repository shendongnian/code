     internal class Program {
        private static readonly DTE2 _dte2;
    
        // Static Constructor
        static Program() {
          _dte2 = (DTE2)Marshal.GetActiveObject("VisualStudio.DTE.15.0");
        }
    
    
        private static void FindProjectsIn(ProjectItem item, List<Project> results) {
          if (item.Object is Project) {
            var proj = (Project) item.Object;
            if (new Guid(proj.Kind) != new Guid(Constants.vsProjectItemKindPhysicalFolder))
              results.Add((Project) item.Object);
            else
              foreach (ProjectItem innerItem in proj.ProjectItems)
                FindProjectsIn(innerItem, results);
          }
    
          if (item.ProjectItems != null)
            foreach (ProjectItem innerItem in item.ProjectItems)
              FindProjectsIn(innerItem, results);
        }
    
    
        private static void FindProjectsIn(UIHierarchyItem item, List<Project> results) {
          if (item.Object is Project) {
            var proj = (Project) item.Object;
            if (new Guid(proj.Kind) != new Guid(Constants.vsProjectItemKindPhysicalFolder))
              results.Add((Project) item.Object);
            else
              foreach (ProjectItem innerItem in proj.ProjectItems)
                FindProjectsIn(innerItem, results);
          }
    
          foreach (UIHierarchyItem innerItem in item.UIHierarchyItems)
            FindProjectsIn(innerItem, results);
        }
    
    
        private static IEnumerable<Project> GetEnvDTEProjectsInSolution() {
          var ret = new List<Project>();
          var hierarchy = _dte2.ToolWindows.SolutionExplorer;
          foreach (UIHierarchyItem innerItem in hierarchy.UIHierarchyItems)
            FindProjectsIn(innerItem, ret);
          return ret;
        }
    
    
        private static void Main() {
          var projects = GetEnvDTEProjectsInSolution();
          var solutiondir = Path.GetDirectoryName(_dte2.Solution.FullName);
          // TODO
          ...
        }
      }
