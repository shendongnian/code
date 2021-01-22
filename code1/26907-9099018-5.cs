    Colors color1 = Colors.Red;
    Console.WriteLine(color1); // #ff0000
    
    Colors color2 = (Colors) "#00ff00";
    Console.WriteLine(color2); // #00ff00
    // Colors color3 = "#0000ff"; // Compilation error
    // String color4 = Colors.Red; // Compilation error
    Colors color5 = (Colors)"#ff0000";
    Console.WriteLine(color1 == color5); // True
            
    Colors color6 = (Colors)"#00ff00";
    Console.WriteLine(color1 == color6); // False
