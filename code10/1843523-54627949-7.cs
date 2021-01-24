    public SimpsonVec SV_Setup(int index){
         SimpsonVec sv;
         sv.A = points[index];
         sv.B = points[index+1];
         sv.C = points[index+2];
         sv.D = points[index+3];
         return sv;
     
     }
     public SimpsonVec[] SV_SETUP_ALL(){
         SimpsonVec[] sv = new SimpsonVec[points.Length / 3];
         for(int i = 0; i<points.Length / 3;i++){
             sv[i] = SV_Setup(i*3);
         }
         return sv;
     }
     public Vector3 GetPoint (Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
         t = Mathf.Clamp01(t);
         float OneMinusT = 1f - t;
         return
             OneMinusT * OneMinusT * OneMinusT * p0 +
             3f * OneMinusT * OneMinusT * t * p1 +
             3f * OneMinusT * t * t * p2 +
             t * t * t * p3;
     }
