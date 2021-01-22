    // Get the vector between the two sprite centres
    Vector v = this.Position - s2.Position;
    // get the radius of a circle that will fit the first sprite
    double d1 = Math.Sqrt(_Image.Width * _Image.Width + _Image.Height * _Image.Height)/2;
    // get the radius of a circle that will fit the second sprite
    double d2 = Math.Sqrt(s2._Image.Width * s2._Image.Width + s2._Image.Height * s2._Image.Height)/2;
    // if the distance between the sprites is larger than the radiuses(radii?) of the circles, they do not collide
    if (v.Length > d1 + d2)
           return false;
