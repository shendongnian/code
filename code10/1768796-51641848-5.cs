    var idState = new AutoIncrement();
    console.WriteLine(idState.GenerateId()); // Outputs 1
    console.WriteLine(idState.GenerateId()); // Outputs 2 
    console.WriteLine(idState.GenerateId()); // Outputs 3 
    console.WriteLine(idState.GenerateId()); // Outputs 4 .. And so on
   
    var idState2 = new AutoIncrement();  // Create a new instance and it starts over
    console.WriteLine(idState2.GenerateId()); // Outputs 1
    console.WriteLine(idState2.GenerateId()); // Outputs 2 .. And so on
    // Go back to idState object and it will keep going from where you last left off
    console.WriteLine(idState.GenerateId()); // Outputs 5 
