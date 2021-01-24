     else if (
                NegCheck(DegreeValue) == true //This just check to see if the angle is negtive
                && 360 + DegreeValue > 180
                && 360 + DegreeValue < 270
                || Between180_270(DegreeValue) == true)
            {
                Console.WriteLine("Angle(" + DegreeValue + ") lies in the 3nd quadrant");
            }
    static public bool Between180_270(double Degreevalue01)
        {
            if (NegCheck(Degreevalue01) == true)
            {
                double step = 0.0;
                step = (360 + Degreevalue01) % 360;
                step = 360 + step;
                if (step > 180 && step < 270)
                {
                    return true;
                }
            }
            return false;
        }
