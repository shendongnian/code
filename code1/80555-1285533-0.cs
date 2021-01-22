      // Among others
      using System.IO;
      using System.Collections.Generic;
    
      class TinyPic {
        public Image Picture;
        public int X;
        public int Y;
            
        public TinyPic(Image picture, int x, int y) {
          Picture = picture;
          X = x;
          Y = y;
        }
      }
        
      class MyForm : Form {
            
        Dictionary<String, TinyPic> tinyPics = new Dictionary<String, TinyPic>();
        
        public MyForm(){
          InitializeComponent(); // assuming Panel myRadarBox
                                 // with your background is there somewhere;
          myRadarBox.Paint += new PaintEventHandler(OnPaintRadar);
        }
        
        void OnPaintRadar(Object sender, PaintEventArgs e){
          foreach(var item in tinyPics){
            TinyPic tp = item.Value;
            e.Graphics.DrawImageUnscaled(tp.Picture, tp.X, tp.Y);
          }
        }
        
        void AddPic(String path, int x, int y){
          if ( File.Exists(path) ){
            var tp = new TinyPic(Image.FromFile(path), x, y);
            tinyPics[path] = tp;
            myRadarBox.Invalidate(new Rectangle(x, y, tp.Width, tp.Height));
          }
        }
            
        void RemovePic(String path){
          TinyPic tp;
          if ( tinyPics.TryGetValue(path, out tp) ){
            tinyPics.Remove(path);
            tp.Picture.Dispose();
            myRadarBox.Invalidate(new Rectangle(tp.X, tp.Y, tp.Width, tp.Height));
          }
        }
      }
