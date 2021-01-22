        public static string RenderView<D>(string path, D dataToBind)
        {
            Page pageHolder = new Page();
            UserControl viewControl = (UserControl) pageHolder.LoadControl(path);
            if(viewControl is IRenderable<D>)
            {
                if (dataToBind != null)
                {
                    ((IRenderable<D>) viewControl).PopulateData(dataToBind);
                }
            }
            pageHolder.Controls.Add(viewControl);
            StringWriter output = new StringWriter();
            HttpContext.Current.Server.Execute(pageHolder, output, false);
            return output.ToString();
        }
