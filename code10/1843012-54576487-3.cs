    class JsHandler
    {
        public void HandleJsCall(int arg)
        {
            MessageBox.Show($"Value Provided From JavaScript: {arg.ToString()}", "C# Method Called");
        }
    }
