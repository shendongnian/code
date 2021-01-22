    public static void AddTemplate(Template template)
		{
			using (TheEntities context = new TheEntities())
			{
				if (template.TemplateType.EntityKey != null)
				{
					TemplateType type = template.TemplateType;
					template.TemplateType = null;
					context.AttachTo("TemplateTypes", type);
					template.TemplateType = type;
				}
				
				context.AddToTemplates(template);
				context.SaveChanges();
				context.RemoveTracking(template);
			}
		}
