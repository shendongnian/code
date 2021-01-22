      // Among others
      using System.Collections.Generic;
      using System.Drawing;
      using System.IO;
    
      class TinyPic {
        public readonly Image Picture;
        public readonly Rectangle Bounds;
            
        public TinyPic(Image picture, int x, int y) {
          Picture = picture;
          Bounds = new Rectangle(x, y, picture.Width, picture.Height);
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
            e.Graphics.DrawImageUnscaled(tp.Picture, tp.Bounds.Location);
          }
        }
        
        void AddPic(String path, int x, int y){
          if ( File.Exists(path) ){
            var tp = new TinyPic(Image.FromFile(path), x, y);
            tinyPics[path] = tp;
            myRadarBox.Invalidate(tp.Bounds);
          }
        }
            
        void RemovePic(String path){
          TinyPic tp;
          if ( tinyPics.TryGetValue(path, out tp) ){
            tinyPics.Remove(path);
            tp.Picture.Dispose();
            myRadarBox.Invalidate(tp.Bounds);
          }
        }
      }
