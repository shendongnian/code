    @inject IJSRuntime js
    @functions {
        void DownloadFile() {
            var text = "Hello, world!";
            var bytes = System.Text.Encoding.UTF8.GetBytes(text);
            FileUtil.SaveAs(js, "HelloWorld.txt", bytes);
        }
    }
