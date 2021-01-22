    public sealed class AsyncWorkExtension 
        : IWorkflowInstanceExtension
    {
        // only one extension per workflow
        private WorkflowInstanceProxy _proxy;
        private Bookmark _lastBookmark;
        /// <summary>
        /// Request the extension does some work for an activity
        /// during which the activity will idle the workflow
        /// </summary>
        /// <param name="toResumeMe"></param>
        public void DoWork(Bookmark toResumeMe)
        {
            _lastBookmark = toResumeMe;
            // imagine I kick off some async op here
            // when complete system calls WorkCompleted below
            // NOTE:  you CANNOT block here or you block the WF!
        }
        /// <summary>
        /// Called by the system when long-running work is complete
        /// </summary>
        /// <param name="result"></param>
        internal void WorkCompleted(object result)
        {
            //NOT good practice!  example only
            //this leaks resources search APM for details
            _proxy.BeginResumeBookmark(_lastBookmark, result, null, null);
        }
        /// <summary>
        /// When implemented, returns any additional extensions 
        /// the implementing class requires.
        /// </summary>
        /// <returns>
        /// A collection of additional workflow extensions.
        /// </returns>
        IEnumerable<object> IWorkflowInstanceExtension
            .GetAdditionalExtensions()
        {
            return new object[0];
        }
        /// <summary>
        /// Sets the specified target 
        /// <see cref="WorkflowInstanceProxy"/>.
        /// </summary>
        /// <param name="instance">The target workflow instance to set.</param>
        void IWorkflowInstanceExtension
            .SetInstance(WorkflowInstanceProxy instance)
        {
            _proxy = instance;
        }
    }
