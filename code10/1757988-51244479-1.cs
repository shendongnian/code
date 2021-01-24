    2018-07-09 14:23:44,561 [11] ERROR TestErrorLogging.MyAPITracer - System.Web.Http.Controllers;TestController;eesage
    System.Exception: Test Exception
       в TestErrorLogging.Controllers.TestController.Get() в C:\Users\Александр\Desktop\TestErrorLogging\TestErrorLogging\Controllers\TestController.cs:строка 15
       в lambda_method(Closure , Object , Object[] )
       в System.Web.Http.Controllers.ReflectedHttpActionDescriptor.ActionExecutor.<>c__DisplayClass10.<GetExecutor>b__9(Object instance, Object[] methodParameters)
       в System.Web.Http.Controllers.ReflectedHttpActionDescriptor.ActionExecutor.Execute(Object instance, Object[] arguments)
       в System.Web.Http.Controllers.ReflectedHttpActionDescriptor.ExecuteAsync(HttpControllerContext controllerContext, IDictionary`2 arguments, CancellationToken cancellationToken)
    --- Конец трассировка стека из предыдущего расположения, где возникло исключение ---
       в System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
       в System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
       в System.Web.Http.Tracing.ITraceWriterExtensions.<TraceBeginEndAsyncCore>d__18`1.MoveNext()
    --- Конец трассировка стека из предыдущего расположения, где возникло исключение ---
       в System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
       в System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
       в System.Web.Http.Controllers.ApiControllerActionInvoker.<InvokeActionAsyncCore>d__0.MoveNext()
    --- Конец трассировка стека из предыдущего расположения, где возникло исключение ---
       в System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
       в System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
       в System.Web.Http.Tracing.ITraceWriterExtensions.<TraceBeginEndAsyncCore>d__18`1.MoveNext()
    --- Конец трассировка стека из предыдущего расположения, где возникло исключение ---
       в System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
       в System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
       в System.Web.Http.Controllers.ActionFilterResult.<ExecuteAsync>d__2.MoveNext()
    --- Конец трассировка стека из предыдущего расположения, где возникло исключение ---
       в System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
       в System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
       в System.Web.Http.Tracing.Tracers.HttpControllerTracer.<ExecuteAsyncCore>d__5.MoveNext()
    --- Конец трассировка стека из предыдущего расположения, где возникло исключение ---
       в System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
       в System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
       в System.Web.Http.Tracing.ITraceWriterExtensions.<TraceBeginEndAsyncCore>d__18`1.MoveNext()
