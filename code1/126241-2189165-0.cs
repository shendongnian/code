    Console.WriteLine("Calculate v_ox");       //Calculate vox = v_ocos(theta 
 
    theta = theta * Math.PI / 180.0;    // Converts from degrees to radians 
    double v_ox = v_o * Math.Cos(theta);      //Use the Math.Cos(theta) method 
    Console.WriteLine("v_ox == {0}", v_ox); // Show this, if you want to see the value
 
    Console.ReadLine(); 
