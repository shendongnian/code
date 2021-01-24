        /// <summary>
        /// BUG Description and History:
        /// We had an issue where the child Tasks/async operations were not inheriting the the current culture of the parent thread;
        /// i.e., even after setting the Thread.CurrentThread.CurrentUICulture in the controller constructor, any Task created within the action was having the invariant culture by default 
        /// unless it is set it separately. This seems to have fixed in framework > 4.0 and was working fine after upgrading the target framework from 3.5.2 to 4.6.2
        /// ref - https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-based-asynchronous-programming
        /// But with this fix in framework, there introduced an unnoticed? bug where in the UI culture do not flow from the calling thread's context to the NewtonSoft Json Serializer write
        /// And hence, any deferred serialization (like IEnumerable) will run under the Invariant Culture (en-US) thus ending up picking the english resource file instead of the culture set for the thread.
        /// This works fine in framework 3.5.2 or if we enable the "Switch.System.Globalization.NoAsyncCurrentCulture" switch in 4.6.2. But using the switch will diable the flow of culture in async operations and will end up having the issue
        /// we had in 3.5.2.
        /// Inorder to fix this issue, the workaround is to force the serialization happen in the action context itself where the thread UI culture is the one we have set.
        /// </summary>
        public class ForceSerializeHttpContentFilter : ActionFilterAttribute
        {
            public override void OnActionExecuted(HttpActionExecutedContext filterContext)
            {
                base.OnActionExecuted(filterContext);
                filterContext.Response.Content.LoadIntoBufferAsync().Wait();
            }
        }
 
