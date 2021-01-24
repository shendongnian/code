    abstract class AbstractClassType {
        public virtual void MethX(){
            //default implementation here.            
        }
        public virtual void MethY(){
            //another default implementation here!
        }
    }
    class T1 : AbstractClassType {
        public override void MethX(){
            //base.MethX() would call the logic in the base class. 
        }
        public override void MethY(){ 
            //base.MethY() would call the logic in the base class. 
        }
    }
