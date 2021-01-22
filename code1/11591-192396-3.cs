     public class PhotoPistol : Gun /* ,Camera */
      { PhotoPistolCamera camera;
        public PhotoPistol() {camera = new PhotoPistolCamera();}
        public void Focus() { camera.Focus(); }
        class PhotoPistolCamera : Camera { public override Focus() { }} 
        public static Camera implicit operator(PhotoPistol p) 
         { return p.camera; 
         }
      }
