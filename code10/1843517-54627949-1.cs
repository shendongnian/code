     //if accuracy is 0.001 = good performance | if 0.000001 laggy performance
        public Vector3[] GetPoints (float gap,float accuracy){
         SimpsonVec sv = SV_Setup(0);
         Vector3 last_spawn = Bezier.GetPoint(sv.A,sv.B,sv.C,sv.D,0);
     
         List<Vector3> allPoints = new List<Vector3>();
         allPoints.Add(last_spawn);
     
         for(float t = accuracy;t <= 1.0f; t +=accuracy){
             Vector3 trial = Bezier.GetPoint(sv.A,sv.B,sv.C,sv.D,t);
             if(Vector3.Distance(trial,last_spawn) >= gap){
                 last_spawn = trial;
                 allPoints.Add(trial);
             }
         }
         return allPoints.ToArray();
     }
