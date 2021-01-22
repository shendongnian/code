        // Create an engine using the templates path as the root location
        // as well as the shared location
        var engine = new SparkViewEngine
            {
                 DefaultPageBaseType = typeof(SparkView).FullName,
                 ViewFolder = viewFolder.Append(new SubViewFolder(viewFolder, "Shared"))
            };
        SparkView view;
        // compile and instantiate the template
        view = (SparkView)engine.CreateInstance(
                              new SparkViewDescriptor()
                                  .AddTemplate(templateName));
        // render the view to stdout
        using (var writer = new StreamWriter(Console.OpenStandardOutput(), Encoding.UTF8))
        {
            view.RenderView(writer);
        }
