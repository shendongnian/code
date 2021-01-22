    abstract class Gun
    { 
        public void Shoot(object target) {} 
        public void Shoot() {}
        
        public abstract void Reload();
        
        public void Cock() { Console.Write("Gun cocked."); }
    }
    class Camera
    { 
        public void Shoot(object subject) {}
        
        public virtual void Reload() {}
        
        public virtual void Focus() {}
    }
    //this is great for taking pictures of targets!
    class PhotoPistol : Gun, Camera
    { 
        public override void Reload() { Console.Write("Gun reloaded."); }
        
        public override void Camera.Reload() { Console.Write("Camera reloaded."); }
        
        public override void Focus() {}
    }
    var    pp      = new PhotoPistol();
    Gun    gun     = pp;
    Camera camera  = pp;
    pp.Shoot();                    //Gun.Shoot()
    pp.Reload();                   //writes "Gun reloaded"
    camera.Reload();               //writes "Camera reloaded"
    pp.Cock();                     //writes "Gun cocked."
    camera.Cock();                 //error: Camera.Cock() not found
    ((PhotoPistol) camera).Cock(); //writes "Gun cocked."
    camera.Shoot();                //error:  Camera.Shoot() not found
    ((PhotoPistol) camera).Shoot();//Gun.Shoot()
    pp.Shoot(target);              //Gun.Shoot(target)
    camera.Shoot(target);          //Camera.Shoot(target)
     
