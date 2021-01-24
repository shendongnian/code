    pageLoad
      if(!IsPostback) {
           // get from query string and populate textboxes.. Compare
           var entry1 = Request.QueryString["entry1"]; ...
           Compare()
      }
    
    btnClick() {
       // get from textboxes 
       var entry1 = input1.Value; ....
       Compare();
    }
