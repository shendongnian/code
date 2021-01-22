    public class ViewManager {
        public static string RenderView(string path, object data) {
                Page pageHolder = new Page();
                UserControl viewControl = (UserControl) pageHolder.LoadControl(path);
                if (data != null) {
                        Type viewControlType = viewControl.GetType();
                        FieldInfo field = viewControlType.GetField("Data");
                        if (field != null) {
                                field.SetValue(viewControl, data);
                        }
                        else {
                                throw new Exception("ViewFile: " + path + "has no data property");
                        }
                }
                pageHolder.Controls.Add(viewControl);
                StringWriter result = new StringWriter();
                HttpContext.Current.Server.Execute(pageHolder, result, false);
                return result.ToString();
    }
