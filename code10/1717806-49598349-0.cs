    public void Axis(){
            pto.x = Xvp2W(250, world, vp); //return 125
            pto.y = Yvp2W(0, world, vp); //return 250
            if(pol.points == null) 
            {
                  pol.points=new PointsCollection();
            }
            pol.points.Add(pto); //pol.pontos return null <- THE ERROR
    }
