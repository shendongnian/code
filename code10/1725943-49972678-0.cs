    public MainPage()
    {
        this.InitializeComponent();
        string html = "<p>Dessy pergi ke pasar dia ingin membeli beberapa macam diantaranya buah apel, cendol, kain untuk pelajaran keterampilan membatik dan pensil. Ukuran-ukuran yang benar dipakai oleh penjual adalah...</p> ";
        webview.NavigateToString(html);
    }
    private async void webview_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
    {
        await webview.InvokeScriptAsync("eval", new string[] { "document.getElementsByTagName(\"p\")[0].style.fontSize=\"" + 30 + "\";" });
    }
