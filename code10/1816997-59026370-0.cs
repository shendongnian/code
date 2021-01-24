    System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation.
     ---> System.NotSupportedException: Ambiguous HTTP method for action - <MyApp>.api.Controllers.MyController.GetAll (<MyApp>.api). Actions require an explicit HttpMethod binding for Swagger 2.0
       at Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator.GenerateOperations(IEnumerable`1 apiDescriptions, SchemaRepository schemaRepository)
       at Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator.GeneratePaths(IEnumerable`1 apiDescriptions, SchemaRepository schemaRepository)
       at Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator.GetSwagger(String documentName, String host, String basePath)
       at Microsoft.Extensions.ApiDescriptions.DocumentProvider.GenerateAsync(String documentName, TextWriter writer)
       --- End of inner exception stack trace ---
       at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor, Boolean wrapExceptions)
       at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
       at System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
       at Microsoft.Extensions.ApiDescription.Tool.Commands.GetDocumentCommandWorker.InvokeMethod(MethodInfo method, Object instance, Object[] arguments)
       at Microsoft.Extensions.ApiDescription.Tool.Commands.GetDocumentCommandWorker.GetDocument(String documentName, String projectName, String outputDirectory, MethodInfo generateMethod, Object service)
       at Microsoft.Extensions.ApiDescription.Tool.Commands.GetDocumentCommandWorker.GetDocuments(GetDocumentCommandContext context, IServiceProvider services)
       at Microsoft.Extensions.ApiDescription.Tool.Commands.GetDocumentCommandWorker.Process(GetDocumentCommandContext context)
		
