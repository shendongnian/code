    public class SolutionEventsListener : IVsSolutionEvents, IDisposable
    {
        private IVsSolution solution;
        private uint solutionEventsCookie;
    
        public event Action AfterSolutionLoaded;
        public event Action BeforeSolutionClosed;
    
        public SolutionEventsListener(IServiceProvider serviceProvider)
        {
            InitNullEvents();
    
            solution = serviceProvider.GetService(typeof (SVsSolution)) as IVsSolution;
            if (solution != null)
            {
                solution.AdviseSolutionEvents(this, out solutionEventsCookie);
            }
        }
    
        private void InitNullEvents()
        {
            AfterSolutionLoaded += () => { };
            BeforeSolutionClosed += () => { };
        }
    
        #region IVsSolutionEvents Members
    
        int IVsSolutionEvents.OnAfterCloseSolution(object pUnkReserved)
        {
            return VSConstants.S_OK;
        }
    
        int IVsSolutionEvents.OnAfterLoadProject(IVsHierarchy pStubHierarchy, IVsHierarchy pRealHierarchy)
        {
            return VSConstants.S_OK;
        }
    
        int IVsSolutionEvents.OnAfterOpenProject(IVsHierarchy pHierarchy, int fAdded)
        {
            return VSConstants.S_OK;
        }
    
        int IVsSolutionEvents.OnAfterOpenSolution(object pUnkReserved, int fNewSolution)
        {
            AfterSolutionLoaded();
            return VSConstants.S_OK;
        }
    
        int IVsSolutionEvents.OnBeforeCloseProject(IVsHierarchy pHierarchy, int fRemoved)
        {
            return VSConstants.S_OK;
        }
    
        int IVsSolutionEvents.OnBeforeCloseSolution(object pUnkReserved)
        {
            BeforeSolutionClosed();
            return VSConstants.S_OK;
        }
    
        int IVsSolutionEvents.OnBeforeUnloadProject(IVsHierarchy pRealHierarchy, IVsHierarchy pStubHierarchy)
        {
            return VSConstants.S_OK;
        }
    
        int IVsSolutionEvents.OnQueryCloseProject(IVsHierarchy pHierarchy, int fRemoving, ref int pfCancel)
        {
            return VSConstants.S_OK;
        }
    
        int IVsSolutionEvents.OnQueryCloseSolution(object pUnkReserved, ref int pfCancel)
        {
            return VSConstants.S_OK;
        }
    
        int IVsSolutionEvents.OnQueryUnloadProject(IVsHierarchy pRealHierarchy, ref int pfCancel)
        {
            return VSConstants.S_OK;
        }
    
        #endregion
    
        #region IDisposable Members
    
        public void Dispose()
        {
            if (solution != null && solutionEventsCookie != 0)
            {
                GC.SuppressFinalize(this);
                solution.UnadviseSolutionEvents(solutionEventsCookie);
                AfterSolutionLoaded = null;
                BeforeSolutionClosed = null;
                solutionEventsCookie = 0;
                solution = null;
            }
        }
    
        #endregion
    }
