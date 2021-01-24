          int x = 100;
          int y = 10;
          Dispatcher.BeginInvoke(new Action( ()=> {
              browser.MouseMove(x, y);
           }
     }
