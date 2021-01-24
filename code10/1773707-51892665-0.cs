    Context context = new Context();
    
    var templateService = new TemplateService(context);
    Template template = templateService.Get(new { host = "Template_test" }).First();
    
    var hostService = new HostService(context);
    Host host = hostService.GetByName("testhost");
    
    host.parentTemplates.Add(template);
    
    var newhost = new NewHost
    {
        Id = host.Id,
        templates = host.parentTemplates
    }
    hostService.Update(newhost);
