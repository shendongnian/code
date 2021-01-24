    Dim Gp1 as new GraphicsPath
    Dim Gp2 as new GraphicsPath
    
    Gp1.Addline(pt1,pt2)
    Gp2.Addline(pt2,pt3)
    Gp2.Addline(pt3,pt5)
         
    
    Dim Reg1 as new region(Gp1)
    Dim Reg2 as new region(Gp2)
        
    Reg1.Intersect(Reg2)
         
    If Not Reg1.IsEmpty(g) Then
    
    Msgbox "Intersection"
    
    End If
