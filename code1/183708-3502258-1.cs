    private static Queue<string> queue = new ...
    
    foreach(string href in hrefs){
        queue.Enqueue(href);
    }
    
    private void webBrowser1_DocumentCompleted(object sender, EventArgs e){
        if(queue.Count>0){
            webBrowser1.Url = queue.Dequeue();
        }
    }
