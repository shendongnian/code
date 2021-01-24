     List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> item = roles.ConvertAll(a =>
                {
                    return new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                    {
                        Text = a.Id.ToString(),
                        Value = a.Name.ToString(),
                    };
                });
