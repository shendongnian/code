    static float a , b , h ;
            static Vector3 MinV = new Vector3(0f, 0f, 0f);
            static Vector3 MaxV = new Vector3(a, b, h);
           
            Vector3 topLeftBack = new Vector3(MinV.X, MaxV.Y, MinV.Z);
            Vector3 topRightBack = new Vector3(MaxV.X, MaxV.Y, MinV.Z);
            Vector3 bottomLeftBack = new Vector3(MinV.X, MinV.Y, MinV.Z); //min
            Vector3 bottomRightBack = new Vector3(MaxV.X, MinV.Y, MinV.Z);
            Vector3 topLeftFront = new Vector3(MinV.X, MaxV.Y, MaxV.Z);
            Vector3 topRightFront = new Vector3(MaxV.X, MaxV.Y, MaxV.Z);  //max  
            Vector3 bottomLeftFront = new Vector3(MinV.X, MinV.Y, MaxV.Z);
            Vector3 bottomRightFront = new Vector3(MaxV.X, MinV.Y, MaxV.Z);
