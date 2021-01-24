    System.AggregateException: One or more errors occurred. ---> System.Exception: Build failed. Check the Output window for more details.
       --- End of inner exception stack trace ---
       at System.Threading.Tasks.Task.ThrowIfExceptional(Boolean includeTaskCanceledExceptions)
       at System.Threading.Tasks.Task.Wait(Int32 millisecondsTimeout, CancellationToken cancellationToken)
       at Microsoft.VisualStudio.Web.Publish.PublishService.VsWebProjectPublish.<>c__DisplayClass43_0.<PublishAsync>b__2()
       at System.Threading.Tasks.Task`1.InnerInvoke()
       at System.Threading.Tasks.Task.Execute()
    --- End of stack trace from previous location where exception was thrown ---
       at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
       at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
       at Microsoft.VisualStudio.ApplicationCapabilities.Publish.ViewModel.ProfileSelectorViewModel.<RunPublishTaskAsync>d__127.MoveNext()
    ---> (Inner Exception #0) System.Exception: Build failed. Check the Output window for more details.<---
