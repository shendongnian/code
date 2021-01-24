     var list = ctx.Web.Lists.GetByTitle(listName);
     var camlQuery = new CamlQuery();
     var query = String.Format(@"<Where><Contains><FieldRef Name='{0}' /><Value Type='Text'>{1}</Value></Contains></Where>",fieldName,fieldValue);
     camlQuery.ViewXml = String.Format("<View><Query>{0}</Query></View>", query);
     var items = list.GetItems(camlQuery);
     ctx.Load(items, icol => icol.Include(
                item => item.Id,
                item => item.DisplayName, item => item.Properties));
     ctx.ExecuteQuery();
