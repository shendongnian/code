    //Sample of MyDownloadUI
    DownloadController controller;
    public MyDownloadUI {
        this.controller = new DownloadController(this);
        //...
    }
    //Sample of DownloadController
    
    DownloadView view;
    
    public DownloadController(DownloadView view) {
        this.view = view;
        //...
    }
